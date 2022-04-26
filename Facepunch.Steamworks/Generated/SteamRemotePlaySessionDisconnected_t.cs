using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamRemotePlaySessionDisconnected_t : ICallbackData {
    internal uint SessionID; // m_unSessionID RemotePlaySessionID_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamRemotePlaySessionDisconnected_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamRemotePlaySessionDisconnected;

#endregion
}
