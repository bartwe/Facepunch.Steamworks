using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUpdatePublishedFileResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUpdatePublishedFileResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageUpdatePublishedFileResult;

#endregion
}
