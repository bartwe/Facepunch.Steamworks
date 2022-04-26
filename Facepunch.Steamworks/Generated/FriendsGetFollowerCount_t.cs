using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsGetFollowerCount_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamID; // m_steamID CSteamID
    internal int Count; // m_nCount int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsGetFollowerCount_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FriendsGetFollowerCount;

#endregion
}
