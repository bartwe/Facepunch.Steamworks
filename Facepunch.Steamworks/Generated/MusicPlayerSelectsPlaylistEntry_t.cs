using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MusicPlayerSelectsPlaylistEntry_t : ICallbackData {
    internal int NID; // nID int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MusicPlayerSelectsPlaylistEntry_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MusicPlayerSelectsPlaylistEntry;

#endregion
}
