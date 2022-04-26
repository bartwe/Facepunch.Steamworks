using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsEnumerateFollowingList_t : ICallbackData {
    internal Result Result; // m_eResult EResult

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal ulong[] GSteamID; // m_rgSteamID CSteamID [50]

    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsEnumerateFollowingList_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FriendsEnumerateFollowingList;

#endregion
}
