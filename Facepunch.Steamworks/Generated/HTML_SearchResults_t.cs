using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_SearchResults_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal uint UnResults; // unResults uint32
    internal uint UnCurrentMatch; // unCurrentMatch uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_SearchResults_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_SearchResults;

#endregion
}