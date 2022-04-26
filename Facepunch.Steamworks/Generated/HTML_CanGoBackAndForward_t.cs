using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_CanGoBackAndForward_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

    [MarshalAs(UnmanagedType.I1)]
    internal bool BCanGoBack; // bCanGoBack bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool BCanGoForward; // bCanGoForward bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_CanGoBackAndForward_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_CanGoBackAndForward;

#endregion
}
