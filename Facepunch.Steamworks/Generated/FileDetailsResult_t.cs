using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FileDetailsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong FileSize; // m_ulFileSize uint64

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)] //  m_FileSHA
    internal byte[] FileSHA; // m_FileSHA uint8 [20]

    internal uint Flags; // m_unFlags uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FileDetailsResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FileDetailsResult;

#endregion
}