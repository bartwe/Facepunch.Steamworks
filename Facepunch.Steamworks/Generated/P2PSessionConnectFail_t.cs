using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct P2PSessionConnectFail_t : ICallbackData {
    internal ulong SteamIDRemote; // m_steamIDRemote CSteamID
    internal byte P2PSessionError; // m_eP2PSessionError uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(P2PSessionConnectFail_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.P2PSessionConnectFail;

#endregion
}