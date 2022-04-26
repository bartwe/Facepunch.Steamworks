using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_UpdateToolTip_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchMsg; // pchMsg const char *

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_UpdateToolTip_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_UpdateToolTip;

#endregion
}