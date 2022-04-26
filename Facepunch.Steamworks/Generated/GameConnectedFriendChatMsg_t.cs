using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameConnectedFriendChatMsg_t : ICallbackData {
    internal ulong SteamIDUser; // m_steamIDUser CSteamID
    internal int MessageID; // m_iMessageID int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedFriendChatMsg_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameConnectedFriendChatMsg;

#endregion
}