using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct GameLobbyJoinRequested_t : ICallbackData {
    internal ulong SteamIDLobby; // m_steamIDLobby CSteamID
    internal ulong SteamIDFriend; // m_steamIDFriend CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameLobbyJoinRequested_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameLobbyJoinRequested;

#endregion
}