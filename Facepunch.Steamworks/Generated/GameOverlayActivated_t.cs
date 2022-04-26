using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GameOverlayActivated_t : ICallbackData {
    internal byte Active; // m_bActive uint8

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GameOverlayActivated_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GameOverlayActivated;

#endregion
}