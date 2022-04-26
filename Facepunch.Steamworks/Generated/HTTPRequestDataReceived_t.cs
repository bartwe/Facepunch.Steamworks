using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTTPRequestDataReceived_t : ICallbackData {
    internal uint Request; // m_hRequest HTTPRequestHandle
    internal ulong ContextValue; // m_ulContextValue uint64
    internal uint COffset; // m_cOffset uint32
    internal uint CBytesReceived; // m_cBytesReceived uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTTPRequestDataReceived_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTTPRequestDataReceived;

#endregion
}
