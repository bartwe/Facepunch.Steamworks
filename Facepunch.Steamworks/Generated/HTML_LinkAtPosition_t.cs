using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_LinkAtPosition_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint X; // x uint32
    internal uint Y; // y uint32
    internal string PchURL; // pchURL const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BInput; // bInput bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool BLiveLink; // bLiveLink bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_LinkAtPosition_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_LinkAtPosition;

#endregion
}
