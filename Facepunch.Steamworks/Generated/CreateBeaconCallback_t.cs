using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct CreateBeaconCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong BeaconID; // m_ulBeaconID PartyBeaconID_t

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(CreateBeaconCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.CreateBeaconCallback;

#endregion
}
