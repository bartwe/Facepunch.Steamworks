using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameConnectedChatJoin_t : ICallbackData {
    internal ulong SteamIDClanChat; // m_steamIDClanChat CSteamID
    internal ulong SteamIDUser; // m_steamIDUser CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatJoin_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameConnectedChatJoin;

#endregion
}