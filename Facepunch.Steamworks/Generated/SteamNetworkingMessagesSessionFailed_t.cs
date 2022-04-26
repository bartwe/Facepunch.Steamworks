using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamNetworkingMessagesSessionFailed_t : ICallbackData {
    internal ConnectionInfo Nfo; // m_info SteamNetConnectionInfo_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingMessagesSessionFailed_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamNetworkingMessagesSessionFailed;

#endregion
}