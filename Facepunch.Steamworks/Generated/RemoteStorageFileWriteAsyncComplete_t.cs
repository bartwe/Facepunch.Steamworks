using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileWriteAsyncComplete_t : ICallbackData {
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileWriteAsyncComplete_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageFileWriteAsyncComplete;

#endregion
}
