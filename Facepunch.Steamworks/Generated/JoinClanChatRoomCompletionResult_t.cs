using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct JoinClanChatRoomCompletionResult_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal RoomEnter ChatRoomEnterResponse; // m_eChatRoomEnterResponse EChatRoomEnterResponse

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(JoinClanChatRoomCompletionResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.JoinClanChatRoomCompletionResult;

#endregion
}