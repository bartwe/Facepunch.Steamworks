using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct MarketEligibilityResponse_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Allowed; // m_bAllowed bool

    internal MarketNotAllowedReasonFlags NotAllowedReason; // m_eNotAllowedReason EMarketNotAllowedReasonFlags
    internal uint TAllowedAtTime; // m_rtAllowedAtTime RTime32
    internal int CdaySteamGuardRequiredDays; // m_cdaySteamGuardRequiredDays int
    internal int CdayNewDeviceCooldown; // m_cdayNewDeviceCooldown int

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(MarketEligibilityResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.MarketEligibilityResponse;

#endregion
}
