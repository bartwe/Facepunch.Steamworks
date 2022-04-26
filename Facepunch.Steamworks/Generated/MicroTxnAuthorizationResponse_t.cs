using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MicroTxnAuthorizationResponse_t : ICallbackData {
    internal uint AppID; // m_unAppID uint32
    internal ulong OrderID; // m_ulOrderID uint64
    internal byte Authorized; // m_bAuthorized uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MicroTxnAuthorizationResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MicroTxnAuthorizationResponse;

#endregion
}
