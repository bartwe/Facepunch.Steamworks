using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_BrowserRestarted_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnOldBrowserHandle; // unOldBrowserHandle HHTMLBrowser

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_BrowserRestarted_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_BrowserRestarted;

#endregion
}