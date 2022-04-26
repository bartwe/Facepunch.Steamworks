using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DurationControl_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal AppId Appid; // m_appid AppId_t

    [MarshalAs(UnmanagedType.I1)]
    internal bool Applicable; // m_bApplicable bool

    internal int CsecsLast5h; // m_csecsLast5h int32
    internal DurationControlProgress Progress; // m_progress EDurationControlProgress
    internal DurationControlNotification Otification; // m_notification EDurationControlNotification
    internal int CsecsToday; // m_csecsToday int32
    internal int CsecsRemaining; // m_csecsRemaining int32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DurationControl_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.DurationControl;

#endregion
}