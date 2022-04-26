using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsLooped_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Looped; // m_bLooped bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsLooped_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWantsLooped;

#endregion
}