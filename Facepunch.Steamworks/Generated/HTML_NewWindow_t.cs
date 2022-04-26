using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_NewWindow_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal uint UnX; // unX uint32
    internal uint UnY; // unY uint32
    internal uint UnWide; // unWide uint32
    internal uint UnTall; // unTall uint32
    internal uint UnNewWindow_BrowserHandle_IGNORE; // unNewWindow_BrowserHandle_IGNORE HHTMLBrowser

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_NewWindow_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_NewWindow;

#endregion
}