using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct ComputeNewPlayerCompatibilityResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int CPlayersThatDontLikeCandidate; // m_cPlayersThatDontLikeCandidate int
    internal int CPlayersThatCandidateDoesntLike; // m_cPlayersThatCandidateDoesntLike int
    internal int CClanPlayersThatDontLikeCandidate; // m_cClanPlayersThatDontLikeCandidate int
    internal ulong SteamIDCandidate; // m_SteamIDCandidate CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ComputeNewPlayerCompatibilityResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ComputeNewPlayerCompatibilityResult;

#endregion
}