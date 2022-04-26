using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyChatUpdate_t : ICallbackData {
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64
    internal ulong SteamIDUserChanged; // m_ulSteamIDUserChanged uint64
    internal ulong SteamIDMakingChange; // m_ulSteamIDMakingChange uint64
    internal uint GfChatMemberStateChange; // m_rgfChatMemberStateChange uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyChatUpdate_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyChatUpdate;

#endregion
}
