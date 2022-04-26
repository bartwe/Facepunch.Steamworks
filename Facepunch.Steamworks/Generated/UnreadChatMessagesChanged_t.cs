using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct UnreadChatMessagesChanged_t : ICallbackData {
#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(UnreadChatMessagesChanged_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.UnreadChatMessagesChanged;

#endregion
}
