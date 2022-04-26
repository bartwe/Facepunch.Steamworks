using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct GetAppDependenciesResult_t : ICallbackData {
    internal Result Result; // m_eResult EResult
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U4)]
    internal AppId[] GAppIDs; // m_rgAppIDs AppId_t [32]

    internal uint NumAppDependencies; // m_nNumAppDependencies uint32
    internal uint TotalNumAppDependencies; // m_nTotalNumAppDependencies uint32

#region SteamCallback

    public static int _datasize = Marshal.SizeOf(typeof(GetAppDependenciesResult_t));

    public int DataSize => _datasize;

    public CallbackType CallbackType => CallbackType.GetAppDependenciesResult;

#endregion
}
