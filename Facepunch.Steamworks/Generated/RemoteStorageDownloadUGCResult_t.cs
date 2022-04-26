using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageDownloadUGCResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong File; // m_hFile UGCHandle_t
    internal AppId AppID; // m_nAppID AppId_t
    internal int SizeInBytes; // m_nSizeInBytes int32

    internal string PchFileNameUTF8() {
        return Encoding.UTF8.GetString(PchFileName, 0, Array.IndexOf<byte>(PchFileName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_pchFileName
    internal byte[] PchFileName; // m_pchFileName char [260]

    internal ulong SteamIDOwner; // m_ulSteamIDOwner uint64

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDownloadUGCResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageDownloadUGCResult;

#endregion
}