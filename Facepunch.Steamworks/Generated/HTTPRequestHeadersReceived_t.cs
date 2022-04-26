using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestHeadersReceived_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestHeadersReceived_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTTPRequestHeadersReceived;

#endregion
}