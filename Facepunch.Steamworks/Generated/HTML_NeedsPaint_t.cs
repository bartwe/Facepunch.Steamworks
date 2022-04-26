using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct HTML_NeedsPaint_t : ICallbackData {
    internal uint UnBrowserHandle; // unBrowserHandle HHTMLBrowser
    internal string PBGRA; // pBGRA const char *
    internal uint UnWide; // unWide uint32
    internal uint UnTall; // unTall uint32
    internal uint UnUpdateX; // unUpdateX uint32
    internal uint UnUpdateY; // unUpdateY uint32
    internal uint UnUpdateWide; // unUpdateWide uint32
    internal uint UnUpdateTall; // unUpdateTall uint32
    internal uint UnScrollX; // unScrollX uint32
    internal uint UnScrollY; // unScrollY uint32
    internal float FlPageScale; // flPageScale float
    internal uint UnPageSerial; // unPageSerial uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(HTML_NeedsPaint_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.HTML_NeedsPaint;

#endregion
}
