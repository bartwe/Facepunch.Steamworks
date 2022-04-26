using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamUGCDetails_t {
    internal PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
    internal Result Result; // m_eResult EResult
    internal WorkshopFileType FileType; // m_eFileType EWorkshopFileType
    internal AppId CreatorAppID; // m_nCreatorAppID AppId_t
    internal AppId ConsumerAppID; // m_nConsumerAppID AppId_t

    internal string TitleUTF8() {
        return Encoding.UTF8.GetString(Title, 0, Array.IndexOf<byte>(Title, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)] // byte[] m_rgchTitle
    internal byte[] Title; // m_rgchTitle char [129]

    internal string DescriptionUTF8() {
        return Encoding.UTF8.GetString(Description, 0, Array.IndexOf<byte>(Description, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8000)] // byte[] m_rgchDescription
    internal byte[] Description; // m_rgchDescription char [8000]

    internal ulong SteamIDOwner; // m_ulSteamIDOwner uint64
    internal uint TimeCreated; // m_rtimeCreated uint32
    internal uint TimeUpdated; // m_rtimeUpdated uint32
    internal uint TimeAddedToUserList; // m_rtimeAddedToUserList uint32
    internal RemoteStoragePublishedFileVisibility Visibility; // m_eVisibility ERemoteStoragePublishedFileVisibility

    [MarshalAs(UnmanagedType.I1)]
    internal bool Banned; // m_bBanned bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool AcceptedForUse; // m_bAcceptedForUse bool

    [MarshalAs(UnmanagedType.I1)]
    internal bool TagsTruncated; // m_bTagsTruncated bool

    internal string TagsUTF8() {
        return Encoding.UTF8.GetString(Tags, 0, Array.IndexOf<byte>(Tags, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)] // byte[] m_rgchTags
    internal byte[] Tags; // m_rgchTags char [1025]

    internal ulong File; // m_hFile UGCHandle_t
    internal ulong PreviewFile; // m_hPreviewFile UGCHandle_t

    internal string PchFileNameUTF8() {
        return Encoding.UTF8.GetString(PchFileName, 0, Array.IndexOf<byte>(PchFileName, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_pchFileName
    internal byte[] PchFileName; // m_pchFileName char [260]

    internal int FileSize; // m_nFileSize int32
    internal int PreviewFileSize; // m_nPreviewFileSize int32

    internal string URLUTF8() {
        return Encoding.UTF8.GetString(URL, 0, Array.IndexOf<byte>(URL, 0));
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchURL
    internal byte[] URL; // m_rgchURL char [256]

    internal uint VotesUp; // m_unVotesUp uint32
    internal uint VotesDown; // m_unVotesDown uint32
    internal float Score; // m_flScore float
    internal uint NumChildren; // m_unNumChildren uint32
}
