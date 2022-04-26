using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileUpdated_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t
    internal ulong Unused; // m_ulUnused uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUpdated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileUpdated;

#endregion
}
