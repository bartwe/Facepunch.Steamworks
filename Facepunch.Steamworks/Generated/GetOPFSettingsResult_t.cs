using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetOPFSettingsResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal AppId VideoAppID; // m_unVideoAppID AppId_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetOPFSettingsResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GetOPFSettingsResult;

#endregion
}