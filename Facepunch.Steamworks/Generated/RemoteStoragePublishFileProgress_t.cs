using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishFileProgress_t : ICallbackData {
    internal double DPercentFile; // m_dPercentFile double

    [MarshalAs(UnmanagedType.I1)]
    internal bool Preview; // m_bPreview bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishFileProgress_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStoragePublishFileProgress;

#endregion
}
