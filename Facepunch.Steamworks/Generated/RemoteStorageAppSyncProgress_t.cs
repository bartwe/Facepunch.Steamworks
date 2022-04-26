using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageAppSyncProgress_t : ICallbackData {
    internal string CurrentFileUTF8() {
        return Encoding.UTF8.GetString(CurrentFile, 0, Array.IndexOf<byte>(CurrentFile, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_rgchCurrentFile
    internal byte[] CurrentFile; // m_rgchCurrentFile char [260]

    internal AppId AppID; // m_nAppID AppId_t
    internal uint BytesTransferredThisChunk; // m_uBytesTransferredThisChunk uint32
    internal double DAppPercentComplete; // m_dAppPercentComplete double

    [MarshalAs(UnmanagedType.I1)]
    internal bool Uploading; // m_bUploading bool

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageAppSyncProgress_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageAppSyncProgress;

#endregion
}
