using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal int ResultsReturned; // m_nResultsReturned int32
    internal int TotalResultCount; // m_nTotalResultCount int32

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
    internal PublishedFileId[] GPublishedFileId; // m_rgPublishedFileId PublishedFileId_t [50]

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSharedWorkshopFilesResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.RemoteStorageEnumerateUserSharedWorkshopFilesResult;

#endregion
}
