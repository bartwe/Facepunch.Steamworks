using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileReadAsyncComplete_t : ICallbackData {
    internal ulong FileReadAsync; // m_hFileReadAsync SteamAPICall_t
    internal Result Result; // m_eResult EResult
    internal uint Offset; // m_nOffset uint32
    internal uint Read; // m_cubRead uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileReadAsyncComplete_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageFileReadAsyncComplete;

#endregion
}