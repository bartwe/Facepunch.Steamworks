using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks {
    /// <summary>
    ///     Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
    /// </summary>
    public sealed class SteamMatchmaking : SteamClientClass<SteamMatchmaking> {
        internal static ISteamMatchmaking Internal {
            get { return Interface as ISteamMatchmaking; }
        }

        /// <summary>
        ///     Maximum number of characters a lobby metadata key can be
        /// </summary>
        internal static int MaxLobbyKeyLength {
            get { return 255; }
        }

        public static LobbyQuery LobbyList {
            get { return new(); }
        }

        internal override bool InitializeInterface(bool server) {
            SetInterface(server, new ISteamMatchmaking(server));
            if (Interface.Self == IntPtr.Zero)
                return false;

            InstallEvents();

            return true;
        }


        internal static void InstallEvents() {
            Dispatch.Install<LobbyInvite_t>(x => OnLobbyInvite?.Invoke(new(x.SteamIDUser), new(x.SteamIDLobby)));

            Dispatch.Install<LobbyEnter_t>(x => OnLobbyEntered?.Invoke(new(x.SteamIDLobby)));

            Dispatch.Install<LobbyCreated_t>(x => OnLobbyCreated?.Invoke(x.Result, new(x.SteamIDLobby)));

            Dispatch.Install<LobbyGameCreated_t>(x => OnLobbyGameCreated?.Invoke(new(x.SteamIDLobby), x.IP, x.Port, x.SteamIDGameServer));

            Dispatch.Install<LobbyDataUpdate_t>(
                x => {
                    if (x.Success == 0)
                        return;

                    if (x.SteamIDLobby == x.SteamIDMember)
                        OnLobbyDataChanged?.Invoke(new(x.SteamIDLobby));
                    else
                        OnLobbyMemberDataChanged?.Invoke(new(x.SteamIDLobby), new(x.SteamIDMember));
                }
            );

            Dispatch.Install<LobbyChatUpdate_t>(
                x => {
                    if ((x.GfChatMemberStateChange & (int)ChatMemberStateChange.Entered) != 0)
                        OnLobbyMemberJoined?.Invoke(new(x.SteamIDLobby), new(x.SteamIDUserChanged));

                    if ((x.GfChatMemberStateChange & (int)ChatMemberStateChange.Left) != 0)
                        OnLobbyMemberLeave?.Invoke(new(x.SteamIDLobby), new(x.SteamIDUserChanged));

                    if ((x.GfChatMemberStateChange & (int)ChatMemberStateChange.Disconnected) != 0)
                        OnLobbyMemberDisconnected?.Invoke(new(x.SteamIDLobby), new(x.SteamIDUserChanged));

                    if ((x.GfChatMemberStateChange & (int)ChatMemberStateChange.Kicked) != 0)
                        OnLobbyMemberKicked?.Invoke(new(x.SteamIDLobby), new(x.SteamIDUserChanged), new(x.SteamIDMakingChange));

                    if ((x.GfChatMemberStateChange & (int)ChatMemberStateChange.Banned) != 0)
                        OnLobbyMemberBanned?.Invoke(new(x.SteamIDLobby), new(x.SteamIDUserChanged), new(x.SteamIDMakingChange));
                }
            );

            Dispatch.Install<LobbyChatMsg_t>(OnLobbyChatMessageRecievedAPI);
        }

        static void OnLobbyChatMessageRecievedAPI(LobbyChatMsg_t callback) {
            SteamId steamid = default;
            ChatEntryType chatEntryType = default;
            var buffer = Helpers.TakeMemory();

            var readData = Internal.GetLobbyChatEntry(callback.SteamIDLobby, (int)callback.ChatID, ref steamid, buffer, Helpers.MemoryBufferSize, ref chatEntryType);

            if (readData > 0) {
                OnChatMessage?.Invoke(new(callback.SteamIDLobby), new(steamid), Helpers.MemoryToString(buffer));
            }
        }

        /// <summary>
        ///     Someone invited you to a lobby
        /// </summary>
        public static event Action<Friend, Lobby> OnLobbyInvite;

        /// <summary>
        ///     You joined a lobby
        /// </summary>
        public static event Action<Lobby> OnLobbyEntered;

        /// <summary>
        ///     You created a lobby
        /// </summary>
        public static event Action<Result, Lobby> OnLobbyCreated;

        /// <summary>
        ///     A game server has been associated with the lobby
        /// </summary>
        public static event Action<Lobby, uint, ushort, SteamId> OnLobbyGameCreated;

        /// <summary>
        ///     The lobby metadata has changed
        /// </summary>
        public static event Action<Lobby> OnLobbyDataChanged;

        /// <summary>
        ///     The lobby member metadata has changed
        /// </summary>
        public static event Action<Lobby, Friend> OnLobbyMemberDataChanged;

        /// <summary>
        ///     The lobby member joined
        /// </summary>
        public static event Action<Lobby, Friend> OnLobbyMemberJoined;

        /// <summary>
        ///     The lobby member left the room
        /// </summary>
        public static event Action<Lobby, Friend> OnLobbyMemberLeave;

        /// <summary>
        ///     The lobby member left the room
        /// </summary>
        public static event Action<Lobby, Friend> OnLobbyMemberDisconnected;

        /// <summary>
        ///     The lobby member was kicked. The 3rd param is the user that kicked them.
        /// </summary>
        public static event Action<Lobby, Friend, Friend> OnLobbyMemberKicked;

        /// <summary>
        ///     The lobby member was banned. The 3rd param is the user that banned them.
        /// </summary>
        public static event Action<Lobby, Friend, Friend> OnLobbyMemberBanned;

        /// <summary>
        ///     A chat message was recieved from a member of a lobby
        /// </summary>
        public static event Action<Lobby, Friend, string> OnChatMessage;

        /// <summary>
        ///     Creates a new invisible lobby. Call lobby.SetPublic to take it online.
        /// </summary>
        public static async Task<Lobby?> CreateLobbyAsync(int maxMembers = 100) {
            var lobby = await Internal.CreateLobby(LobbyType.Invisible, maxMembers);
            if (!lobby.HasValue || (lobby.Value.Result != Result.OK))
                return null;

            return new Lobby { Id = lobby.Value.SteamIDLobby };
        }

        /// <summary>
        ///     Attempts to directly join the specified lobby
        /// </summary>
        public static async Task<Lobby?> JoinLobbyAsync(SteamId lobbyId) {
            var lobby = await Internal.JoinLobby(lobbyId);
            if (!lobby.HasValue)
                return null;

            return new Lobby { Id = lobby.Value.SteamIDLobby };
        }

        /// <summary>
        ///     Get a list of servers that are on your favorites list
        /// </summary>
        public static IEnumerable<ServerInfo> GetFavoriteServers() {
            var count = Internal.GetFavoriteGameCount();

            for (var i = 0; i < count; i++) {
                uint timeplayed = 0;
                uint flags = 0;
                ushort qport = 0;
                ushort cport = 0;
                uint ip = 0;
                AppId appid = default;

                if (Internal.GetFavoriteGame(i, ref appid, ref ip, ref cport, ref qport, ref flags, ref timeplayed)) {
                    if ((flags & ServerInfo.k_unFavoriteFlagFavorite) == 0)
                        continue;
                    yield return new(ip, cport, qport, timeplayed);
                }
            }
        }

        /// <summary>
        ///     Get a list of servers that you have added to your play history
        /// </summary>
        public static IEnumerable<ServerInfo> GetHistoryServers() {
            var count = Internal.GetFavoriteGameCount();

            for (var i = 0; i < count; i++) {
                uint timeplayed = 0;
                uint flags = 0;
                ushort qport = 0;
                ushort cport = 0;
                uint ip = 0;
                AppId appid = default;

                if (Internal.GetFavoriteGame(i, ref appid, ref ip, ref cport, ref qport, ref flags, ref timeplayed)) {
                    if ((flags & ServerInfo.k_unFavoriteFlagHistory) == 0)
                        continue;
                    yield return new(ip, cport, qport, timeplayed);
                }
            }
        }
    }
}
