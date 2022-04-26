using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DownloadItemResult_t : ICallbackData {
    internal AppId AppID; // m_unAppID AppId_t
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DownloadItemResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.DownloadItemResult;

#endregion
}