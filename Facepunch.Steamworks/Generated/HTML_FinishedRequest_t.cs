using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_FinishedRequest_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal string PchPageTitle; // pchPageTitle const char *

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_FinishedRequest_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_FinishedRequest;

#endregion
}