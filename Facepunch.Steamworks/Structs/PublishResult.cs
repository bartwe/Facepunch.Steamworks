using Steamworks.Data;

namespace Steamworks.Ugc;

public struct PublishResult {
    public bool Success => Result == Result.OK;

    public Result Result;
    public PublishedFileId FileId;

    /// <summary>
    ///     https://partner.steamgames.com/doc/features/workshop/implementation#Legal
    /// </summary>
    public bool NeedsWorkshopAgreement;
}
