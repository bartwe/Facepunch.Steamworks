using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerRemoteWillDeactivate_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteWillDeactivate_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerRemoteWillDeactivate;

#endregion
}