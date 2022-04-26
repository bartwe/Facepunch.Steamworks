using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct FriendRichPresenceUpdate_t : ICallbackData {
    internal ulong SteamIDFriend; // m_steamIDFriend CSteamID
    internal AppId AppID; // m_nAppID AppId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(FriendRichPresenceUpdate_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.FriendRichPresenceUpdate;

#endregion
}
