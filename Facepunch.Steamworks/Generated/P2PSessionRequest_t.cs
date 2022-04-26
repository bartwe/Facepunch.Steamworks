using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct P2PSessionRequest_t : ICallbackData {
    internal ulong SteamIDRemote; // m_steamIDRemote CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(P2PSessionRequest_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.P2PSessionRequest;

#endregion
}
