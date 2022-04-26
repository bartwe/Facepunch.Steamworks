using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct LobbyMatchList_t : ICallbackData {
    internal uint LobbiesMatching; // m_nLobbiesMatching uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(LobbyMatchList_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.LobbyMatchList;

#endregion
}
