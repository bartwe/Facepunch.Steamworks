using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyChatMsg_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDUser; // m_ulSteamIDUser uint64
    internal byte ChatEntryType; // m_eChatEntryType uint8
    internal uint ChatID; // m_iChatID uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyChatMsg_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyChatMsg;

#endregion
}
