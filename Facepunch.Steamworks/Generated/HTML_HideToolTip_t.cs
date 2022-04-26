using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_HideToolTip_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_HideToolTip_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_HideToolTip;

#endregion
}