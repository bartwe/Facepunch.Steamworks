using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct FriendsIsFollowing_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamID; // m_steamID CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool IsFollowing; // m_bIsFollowing bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendsIsFollowing_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FriendsIsFollowing;

#endregion
}
