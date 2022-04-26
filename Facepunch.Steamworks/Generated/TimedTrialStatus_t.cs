using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct TimedTrialStatus_t : ICallbackData {
    internal AppId AppID; // m_unAppID AppId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool IsOffline; // m_bIsOffline bool

    internal uint SecondsAllowed; // m_unSecondsAllowed uint32
    internal uint SecondsPlayed; // m_unSecondsPlayed uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(TimedTrialStatus_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.TimedTrialStatus;

#endregion
}
