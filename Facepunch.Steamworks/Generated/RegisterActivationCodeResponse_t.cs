using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RegisterActivationCodeResponse_t : ICallbackData {
    internal RegisterActivationCodeResult Result; // m_eResult ERegisterActivationCodeResult
    internal uint PackageRegistered; // m_unPackageRegistered uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RegisterActivationCodeResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RegisterActivationCodeResponse;

#endregion
}