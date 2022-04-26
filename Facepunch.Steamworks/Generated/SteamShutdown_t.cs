using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamShutdown_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamShutdown_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamShutdown;

#endregion
}
