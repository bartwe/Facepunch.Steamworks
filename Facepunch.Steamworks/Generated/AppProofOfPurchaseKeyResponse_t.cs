using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct AppProofOfPurchaseKeyResponse_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal uint AppID; // m_nAppID uint32
    internal uint CchKeyLength; // m_cchKeyLength uint32

    internal string KeyUTF8() {
        return Encoding.UTF8.GetString(Key, 0, Array.IndexOf<byte>(Key, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)] // byte[] m_rgchKey
    internal byte[] Key; // m_rgchKey char [240]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(AppProofOfPurchaseKeyResponse_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.AppProofOfPurchaseKeyResponse;

#endregion
}