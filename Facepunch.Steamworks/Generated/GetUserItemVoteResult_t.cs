using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetUserItemVoteResult_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool VotedUp; // m_bVotedUp bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool VotedDown; // m_bVotedDown bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool VoteSkipped; // m_bVoteSkipped bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetUserItemVoteResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GetUserItemVoteResult;

#endregion
}
