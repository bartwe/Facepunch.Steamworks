using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyInvite_t : ICallbackData {
    internal ulong SteamIDUser; // m_ulSteamIDUser uint64
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong GameID; // m_ulGameID uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyInvite_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyInvite;

#endregion
}