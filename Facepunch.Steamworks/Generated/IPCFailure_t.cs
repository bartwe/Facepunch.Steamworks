using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct IPCFailure_t : ICallbackData {
    internal byte FailureType; // m_eFailureType uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(IPCFailure_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.IPCFailure;

#endregion

    internal enum EFailureType {
        FlushedCallbackQueue = 0,
        PipeFail = 1,
    }
}
