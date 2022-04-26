using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsShuffled_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Shuffled; // m_bShuffled bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsShuffled_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWantsShuffled;

#endregion
}