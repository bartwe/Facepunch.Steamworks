using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageGetPublishedItemVoteDetailsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_unPublishedFileId PublishedFileId_t
    internal int VotesFor; // m_nVotesFor int32
    internal int VotesAgainst; // m_nVotesAgainst int32
    internal int Reports; // m_nReports int32
    internal float FScore; // m_fScore float

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageGetPublishedItemVoteDetailsResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageGetPublishedItemVoteDetailsResult;

#endregion
}
