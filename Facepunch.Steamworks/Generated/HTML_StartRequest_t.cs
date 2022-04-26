using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_StartRequest_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PchURL; // pchURL const char *
    internal string PchTarget; // pchTarget const char *
    internal string PchPostData; // pchPostData const char *

    [MarshalAs(UnmanagedType.I1)]
    internal bool BIsRedirect; // bIsRedirect bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_StartRequest_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_StartRequest;

#endregion
}