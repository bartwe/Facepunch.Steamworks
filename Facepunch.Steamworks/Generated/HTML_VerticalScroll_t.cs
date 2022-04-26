using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_VerticalScroll_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnScrollMax; // unScrollMax uint32
    internal uint UnScrollCurrent; // unScrollCurrent uint32
    internal float FlPageScale; // flPageScale float

    [MarshalAs(UnmanagedType.I1)]
    internal bool BVisible; // bVisible bool

    internal uint UnPageSize; // unPageSize uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_VerticalScroll_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_VerticalScroll;

#endregion
}
