using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamAppUninstalled_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamAppUninstalled_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamAppUninstalled;

#endregion
}