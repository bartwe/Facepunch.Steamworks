using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SubmitItemUpdateResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool UserNeedsToAcceptWorkshopLegalAgreement; // m_bUserNeedsToAcceptWorkshopLegalAgreement bool

    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SubmitItemUpdateResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SubmitItemUpdateResult;

#endregion
}
