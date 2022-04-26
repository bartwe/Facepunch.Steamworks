using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct ScreenshotReady_t : ICallbackData {
    internal uint Local; // m_hLocal ScreenshotHandle
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(ScreenshotReady_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.ScreenshotReady;

#endregion
}