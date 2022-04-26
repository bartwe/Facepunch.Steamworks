using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageUserVoteDetails_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal WorkshopVote Vote; // m_eVote EWorkshopVote

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUserVoteDetails_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageUserVoteDetails;

#endregion
}
