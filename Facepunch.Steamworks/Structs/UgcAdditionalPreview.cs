namespace Steamworks.Data;

public struct UgcAdditionalPreview {
    internal UgcAdditionalPreview(string urlOrVideoID, string originalFileName, ItemPreviewType itemPreviewType) {
        UrlOrVideoID = urlOrVideoID;
        OriginalFileName = originalFileName;
        ItemPreviewType = itemPreviewType;
    }

    public string UrlOrVideoID { get; }
    public string OriginalFileName { get; }
    public ItemPreviewType ItemPreviewType { get; }
}
