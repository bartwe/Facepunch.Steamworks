using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerWantsPlayingRepeatStatus_t : ICallbackData {
    internal int PlayingRepeatStatus; // m_nPlayingRepeatStatus int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayingRepeatStatus_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerWantsPlayingRepeatStatus;

#endregion
}