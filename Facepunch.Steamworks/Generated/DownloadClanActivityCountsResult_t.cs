using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct DownloadClanActivityCountsResult_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Success; // m_bSuccess bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(DownloadClanActivityCountsResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.DownloadClanActivityCountsResult;

#endregion
}