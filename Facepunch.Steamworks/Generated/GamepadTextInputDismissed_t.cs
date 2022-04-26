using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GamepadTextInputDismissed_t : ICallbackData {
    [MarshalAs(UnmanagedType.I1)]
    internal bool Submitted; // m_bSubmitted bool

    internal uint SubmittedText; // m_unSubmittedText uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GamepadTextInputDismissed_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GamepadTextInputDismissed;

#endregion
}
