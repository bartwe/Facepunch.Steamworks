using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamInventoryRequestPricesResult_t : ICallbackData {
    internal Result Result; // m_result EResult

    internal string CurrencyUTF8() {
        return Encoding.UTF8.GetString(Currency, 0, Array.IndexOf<byte>(Currency, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] // byte[] m_rgchCurrency
    internal byte[] Currency; // m_rgchCurrency char [4]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(SteamInventoryRequestPricesResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.SteamInventoryRequestPricesResult;

#endregion
}