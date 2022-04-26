using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_JSAlert_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMessage; // pchMessage const char *

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_JSAlert_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_JSAlert;

#endregion
}