using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncedServer_t : ICallbackData {
    internal AppId AppID; // m_nAppID AppId_t
    internal Result Result; // m_eResult EResult
    internal int NumUploads; // m_unNumUploads int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncedServer_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageAppSyncedServer;

#endregion
}
