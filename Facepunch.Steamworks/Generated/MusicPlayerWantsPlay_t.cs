using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlay_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlay_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlay;

#endregion
}
