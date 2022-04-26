using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestCompleted_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64

    [MarshalAs(UnmanagedType.I1)]
    internal bool RequestSuccessful; // m_bRequestSuccessful bool

    internal HTTPStatusCode StatusCode; // m_eStatusCode EHTTPStatusCode
    internal uint BodySize; // m_unBodySize uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestCompleted_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTTPRequestCompleted;

#endregion
}
