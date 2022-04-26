using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AvatarImageLoaded_t : ICallbackData {
    internal ulong SteamID; // m_steamID CSteamID
    internal int Image; // m_iImage int
    internal int Wide; // m_iWide int
    internal int Tall; // m_iTall int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AvatarImageLoaded_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.AvatarImageLoaded;

#endregion
}