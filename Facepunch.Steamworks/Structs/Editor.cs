using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Steamworks.Data;
using QueryType = Steamworks.Ugc.Query;

namespace Steamworks.Ugc;

public struct Editor {
    PublishedFileId fileId;

    readonly bool creatingNew;
    readonly WorkshopFileType creatingType;
    AppId consumerAppId;

    internal Editor(WorkshopFileType filetype) : this() {
        creatingNew = true;
        creatingType = filetype;
    }

    public Editor(PublishedFileId fileId) : this() {
        this.fileId = fileId;
    }

    /// <summary>
    ///     Create a Normal Workshop item that can be subscribed to
    /// </summary>
    public static Editor NewCommunityFile => new(WorkshopFileType.Community);

    /// <summary>
    ///     Create a Collection
    ///     Add items using Item.AddDependency()
    /// </summary>
    public static Editor NewCollection => new(WorkshopFileType.Collection);

    /// <summary>
    ///     Workshop item that is meant to be voted on for the purpose of selling in-game
    /// </summary>
    public static Editor NewMicrotransactionFile => new(WorkshopFileType.Microtransaction);

    /// <summary>
    ///     Workshop item that is meant to be managed by the game. It is queryable by the API, but isn't visible on the web
    ///     browser.
    /// </summary>
    public static Editor NewGameManagedFile => new(WorkshopFileType.GameManagedItem);

    public Editor ForAppId(AppId id) {
        consumerAppId = id;
        return this;
    }

    string Title;

    public Editor WithTitle(string t) {
        Title = t;
        return this;
    }

    string Description;

    public Editor WithDescription(string t) {
        Description = t;
        return this;
    }

    string MetaData;

    public Editor WithMetaData(string t) {
        MetaData = t;
        return this;
    }

    string ChangeLog;

    public Editor WithChangeLog(string t) {
        ChangeLog = t;
        return this;
    }

    string Language;

    public Editor InLanguage(string t) {
        Language = t;
        return this;
    }

    string PreviewFile;

    public Editor WithPreviewFile(string t) {
        PreviewFile = t;
        return this;
    }

    DirectoryInfo ContentFolder;

    public Editor WithContent(DirectoryInfo t) {
        ContentFolder = t;
        return this;
    }

    public Editor WithContent(string folderName) {
        return WithContent(new DirectoryInfo(folderName));
    }

    RemoteStoragePublishedFileVisibility? Visibility;

    public Editor WithPublicVisibility() {
        Visibility = RemoteStoragePublishedFileVisibility.Public;
        return this;
    }

    public Editor WithFriendsOnlyVisibility() {
        Visibility = RemoteStoragePublishedFileVisibility.FriendsOnly;
        return this;
    }

    public Editor WithPrivateVisibility() {
        Visibility = RemoteStoragePublishedFileVisibility.Private;
        return this;
    }

    List<string> Tags;
    Dictionary<string, List<string>> KeyValueTags;
    HashSet<string> KeyValueTagsToRemove;

    public Editor WithTag(string tag) {
        if (Tags == null)
            Tags = new();

        Tags.Add(tag);

        return this;
    }

    /// <summary>
    ///     Adds a key-value tag pair to an item.
    ///     Keys can map to multiple different values (1-to-many relationship).
    ///     Key names are restricted to alpha-numeric characters and the '_' character.
    ///     Both keys and values cannot exceed 255 characters in length. Key-value tags are searchable by exact match only.
    ///     To replace all values associated to one key use RemoveKeyValueTags then AddKeyValueTag.
    /// </summary>
    public Editor AddKeyValueTag(string key, string value) {
        if (KeyValueTags == null)
            KeyValueTags = new();

        if (KeyValueTags.TryGetValue(key, out var list))
            list.Add(value);
        else
            KeyValueTags[key] = new() { value };

        return this;
    }

    /// <summary>
    ///     Removes a key and all values associated to it.
    ///     You can remove up to 100 keys per item update.
    ///     If you need remove more tags than that you'll need to make subsequent item updates.
    /// </summary>
    public Editor RemoveKeyValueTags(string key) {
        if (KeyValueTagsToRemove == null)
            KeyValueTagsToRemove = new();

        _ = KeyValueTagsToRemove.Add(key);
        return this;
    }

    public async Task<PublishResult> SubmitAsync(IProgress<float> progress = null, Action<PublishResult> onItemCreated = null) {
        var result = default(PublishResult);

        progress?.Report(0);

        if (consumerAppId == 0)
            consumerAppId = SteamClient.AppId;

        //
        // Checks
        //
        if (ContentFolder != null) {
            if (!Directory.Exists(ContentFolder.FullName))
                throw new($"UgcEditor - Content Folder doesn't exist ({ContentFolder.FullName})");

            if (!ContentFolder.EnumerateFiles("*", SearchOption.AllDirectories).Any())
                throw new("UgcEditor - Content Folder is empty");
        }


        //
        // Item Create
        //
        if (creatingNew) {
            result.Result = Result.Fail;

            var created = await SteamUGC.Internal.CreateItem(consumerAppId, creatingType);
            if (!created.HasValue)
                return result;

            result.Result = created.Value.Result;

            if (result.Result != Result.OK)
                return result;

            fileId = created.Value.PublishedFileId;
            result.NeedsWorkshopAgreement = created.Value.UserNeedsToAcceptWorkshopLegalAgreement;
            result.FileId = fileId;

            onItemCreated?.Invoke(result);
        }


        result.FileId = fileId;

        //
        // Item Update
        //
        {
            var handle = SteamUGC.Internal.StartItemUpdate(consumerAppId, fileId);
            if (handle == 0xffffffffffffffff)
                return result;

            if (Title != null)
                _ = SteamUGC.Internal.SetItemTitle(handle, Title);
            if (Description != null)
                _ = SteamUGC.Internal.SetItemDescription(handle, Description);
            if (MetaData != null)
                _ = SteamUGC.Internal.SetItemMetadata(handle, MetaData);
            if (Language != null)
                _ = SteamUGC.Internal.SetItemUpdateLanguage(handle, Language);
            if (ContentFolder != null)
                _ = SteamUGC.Internal.SetItemContent(handle, ContentFolder.FullName);
            if (PreviewFile != null)
                _ = SteamUGC.Internal.SetItemPreview(handle, PreviewFile);
            if (Visibility.HasValue)
                _ = SteamUGC.Internal.SetItemVisibility(handle, Visibility.Value);
            if ((Tags != null) && (Tags.Count > 0)) {
                using var a = SteamParamStringArray.From(Tags.ToArray());
                var val = a.Value;
                _ = SteamUGC.Internal.SetItemTags(handle, ref val);
            }

            if (KeyValueTagsToRemove != null) {
                foreach (var key in KeyValueTagsToRemove)
                    _ = SteamUGC.Internal.RemoveItemKeyValueTags(handle, key);
            }

            if (KeyValueTags != null) {
                foreach (var keyWithValues in KeyValueTags) {
                    var key = keyWithValues.Key;
                    foreach (var value in keyWithValues.Value)
                        _ = SteamUGC.Internal.AddItemKeyValueTag(handle, key, value);
                }
            }

            result.Result = Result.Fail;

            if (ChangeLog == null)
                ChangeLog = "";

            var updating = SteamUGC.Internal.SubmitItemUpdate(handle, ChangeLog);

            while (!updating.IsCompleted) {
                if (progress != null) {
                    ulong total = 0;
                    ulong processed = 0;

                    var r = SteamUGC.Internal.GetItemUpdateProgress(handle, ref processed, ref total);

                    switch (r) {
                        case ItemUpdateStatus.PreparingConfig: {
                            progress?.Report(0.1f);
                            break;
                        }

                        case ItemUpdateStatus.PreparingContent: {
                            progress?.Report(0.2f);
                            break;
                        }
                        case ItemUpdateStatus.UploadingContent: {
                            var uploaded = total > 0 ? processed / (float)total : 0.0f;
                            progress?.Report(0.2f + (uploaded * 0.7f));
                            break;
                        }
                        case ItemUpdateStatus.UploadingPreviewFile: {
                            progress?.Report(0.8f);
                            break;
                        }
                        case ItemUpdateStatus.CommittingChanges: {
                            progress?.Report(1);
                            break;
                        }
                    }
                }

                await Task.Delay(1000 / 60);
            }

            progress?.Report(1);

            var updated = updating.GetResult();

            if (!updated.HasValue)
                return result;

            result.Result = updated.Value.Result;

            if (result.Result != Result.OK)
                return result;

            result.NeedsWorkshopAgreement = updated.Value.UserNeedsToAcceptWorkshopLegalAgreement;
            result.FileId = fileId;
        }

        return result;
    }
}