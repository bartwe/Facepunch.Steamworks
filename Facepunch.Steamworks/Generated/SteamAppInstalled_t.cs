using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAppInstalled_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAppInstalled_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamAppInstalled;

#endregion
}
