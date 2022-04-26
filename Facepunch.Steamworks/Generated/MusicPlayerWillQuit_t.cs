using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWillQuit_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWillQuit_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWillQuit;

#endregion
}
