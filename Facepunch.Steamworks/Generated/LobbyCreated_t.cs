using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyCreated_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong SteamIDLobby; // m_ulSteamIDLobby uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyCreated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyCreated;

#endregion
}