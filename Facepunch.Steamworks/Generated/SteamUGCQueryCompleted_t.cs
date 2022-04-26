using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamUGCQueryCompleted_t : ICallbackData {
    internal ulong Handle; // m_handle UGCQueryHandle_t
    internal Result Result; // m_eResult EResult
    internal uint NumResultsReturned; // m_unNumResultsReturned uint32
    internal uint TotalMatchingResults; // m_unTotalMatchingResults uint32

    [MarshalAs(UnmanagedType.I1)]
    internal bool CachedData; // m_bCachedData bool

    internal string NextCursorUTF8() {
        return Encoding.UTF8.GetString(NextCursor, 0, Array.IndexOf<byte>(NextCursor, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchNextCursor
    internal byte[] NextCursor; // m_rgchNextCursor char [256]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamUGCQueryCompleted_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamUGCQueryCompleted;

#endregion
}
