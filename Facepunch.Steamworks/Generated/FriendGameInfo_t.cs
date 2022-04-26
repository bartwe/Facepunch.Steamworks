using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendGameInfo_t {
    internal GameId GameID; // m_gameID CGameID
    internal uint GameIP; // m_unGameIP uint32
    internal ushort GamePort; // m_usGamePort uint16
    internal ushort QueryPort; // m_usQueryPort uint16
    internal ulong SteamIDLobby; // m_steamIDLobby CSteamID
}