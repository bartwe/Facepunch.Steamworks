using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SearchForGameProgressCallback_t : ICallbackData {
    internal ulong LSearchID; // m_ullSearchID uint64
    internal Result Result; // m_eResult EResult
    internal ulong LobbyID; // m_lobbyID CSteamID
    internal ulong SteamIDEndedSearch; // m_steamIDEndedSearch CSteamID
    internal int SecondsRemainingEstimate; // m_nSecondsRemainingEstimate int32
    internal int CPlayersSearching; // m_cPlayersSearching int32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SearchForGameProgressCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SearchForGameProgressCallback;

#endregion
}