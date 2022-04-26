using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPackSize)]
struct SubmitPlayerResultResultCallback_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong UllUniqueGameID; // ullUniqueGameID uint64
    internal ulong SteamIDPlayer; // steamIDPlayer CSteamID

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SubmitPlayerResultResultCallback_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SubmitPlayerResultResultCallback;

#endregion
}
