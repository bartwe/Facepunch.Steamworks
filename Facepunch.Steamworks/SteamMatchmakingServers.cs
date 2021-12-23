using System;

namespace Steamworks;

/// <summary>
///     Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
/// </summary>
sealed class SteamMatchmakingServers : SteamClientClass<SteamMatchmakingServers> {
    internal static ISteamMatchmakingServers Internal {
        get { return Interface as ISteamMatchmakingServers; }
    }

    internal override bool InitializeInterface(bool server) {
        SetInterface(server, new ISteamMatchmakingServers(server));
        if (Interface.Self == IntPtr.Zero)
            return false;

        return true;
    }
}
