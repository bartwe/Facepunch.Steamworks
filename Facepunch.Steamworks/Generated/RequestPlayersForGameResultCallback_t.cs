using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct RequestPlayersForGameResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong LSearchID; // m_ullSearchID uint64
    internal ulong SteamIDPlayerFound; // m_SteamIDPlayerFound CSteamID
    internal ulong SteamIDLobby; // m_SteamIDLobby CSteamID
    internal PlayerAcceptState_t PlayerAcceptState; // m_ePlayerAcceptState RequestPlayersForGameResultCallback_t::PlayerAcceptState_t
    internal int PlayerIndex; // m_nPlayerIndex int32
    internal int TotalPlayersFound; // m_nTotalPlayersFound int32
    internal int TotalPlayersAcceptedGame; // m_nTotalPlayersAcceptedGame int32
    internal int SuggestedTeamIndex; // m_nSuggestedTeamIndex int32
    internal ulong LUniqueGameID; // m_ullUniqueGameID uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameResultCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RequestPlayersForGameResultCallback;

#endregion

    internal enum PlayerAcceptState_t {
        Unknown = 0,
        PlayerAccepted = 1,
        PlayerDeclined = 2,
    }
}