using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedClanChatMsg_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID
    internal int MessageID; // m_iMessageID int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedClanChatMsg_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameConnectedClanChatMsg;

#endregion
}