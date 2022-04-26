using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsVolume_t : ICallbackData {
    internal float NewVolume; // m_flNewVolume float

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsVolume_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWantsVolume;

#endregion
}
