using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SearchForGameResultCallback_t : ICallbackData {
    internal ulong LSearchID; // m_ullSearchID uint64
    internal Result Result; // m_eResult EResult
    internal int CountPlayersInGame; // m_nCountPlayersInGame int32
    internal int CountAcceptedGame; // m_nCountAcceptedGame int32
    internal ulong SteamIDHost; // m_steamIDHost CSteamID

    [MarshalAs(UnmanagedType.I1)]
    internal bool FinalCallback; // m_bFinalCallback bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SearchForGameResultCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SearchForGameResultCallback;

#endregion
}