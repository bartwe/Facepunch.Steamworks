using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetConnectionStatusChangedCallback_t : ICallbackData {
    internal Connection Conn; // m_hConn HSteamNetConnection
    internal ConnectionInfo Nfo; // m_info SteamNetConnectionInfo_t
    internal ConnectionState OldState; // m_eOldState ESteamNetworkingConnectionState

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetConnectionStatusChangedCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamNetConnectionStatusChangedCallback;

#endregion
}