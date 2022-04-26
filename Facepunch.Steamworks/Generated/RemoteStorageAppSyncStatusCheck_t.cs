using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncStatusCheck_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t
    internal Result Result; // m_eResult EResult

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncStatusCheck_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageAppSyncStatusCheck;

#endregion
}