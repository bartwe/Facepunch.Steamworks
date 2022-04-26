using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct EndGameResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong UllUniqueGameID; // ullUniqueGameID uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(EndGameResultCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.EndGameResultCallback;

#endregion
}