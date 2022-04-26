using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_SetCursor_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint EMouseCursor; // eMouseCursor uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_SetCursor_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_SetCursor;

#endregion
}
