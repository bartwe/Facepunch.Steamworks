using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SetUserItemVoteResult_t : ICallbackData {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.I1)]
    internal bool VoteUp; // m_bVoteUp bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SetUserItemVoteResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SetUserItemVoteResult;

#endregion
}
