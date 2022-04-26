using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStoragePublishedFileUnsubscribed_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal AppId AppID; // m_nAppID AppId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUnsubscribed_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStoragePublishedFileUnsubscribed;

#endregion
}
