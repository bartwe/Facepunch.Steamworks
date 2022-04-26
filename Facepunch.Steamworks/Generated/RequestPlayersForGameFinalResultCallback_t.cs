using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RequestPlayersForGameFinalResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong LSearchID; // m_ullSearchID uint64
    internal ulong LUniqueGameID; // m_ullUniqueGameID uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameFinalResultCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RequestPlayersForGameFinalResultCallback;

#endregion
}