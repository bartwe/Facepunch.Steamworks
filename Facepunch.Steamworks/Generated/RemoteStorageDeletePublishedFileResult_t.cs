using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageDeletePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDeletePublishedFileResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageDeletePublishedFileResult;

#endregion
}
