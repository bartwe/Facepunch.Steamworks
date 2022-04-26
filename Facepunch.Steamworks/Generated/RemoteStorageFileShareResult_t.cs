using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageFileShareResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal ulong File; // m_hFile UGCHandle_t

    internal string FilenameUTF8() {
        return Encoding.UTF8.GetString(Filename, 0, Array.IndexOf<byte>(Filename, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_rgchFilename
    internal byte[] Filename; // m_rgchFilename char [260]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileShareResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageFileShareResult;

#endregion
}
