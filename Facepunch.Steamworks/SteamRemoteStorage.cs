﻿using System;
using System.Collections.Generic;

namespace Steamworks;

/// <summary>
///     Undocumented Parental Settings
/// </summary>
public sealed class SteamRemoteStorage : SteamClientClass<SteamRemoteStorage> {
    internal static ISteamRemoteStorage Internal {
        get { return Interface as ISteamRemoteStorage; }
    }


    /// <summary>
    ///     Number of bytes total
    /// </summary>
    public static ulong QuotaBytes {
        get {
            ulong t = 0, a = 0;
            _ = Internal.GetQuota(ref t, ref a);
            return t;
        }
    }

    /// <summary>
    ///     Number of bytes used
    /// </summary>
    public static ulong QuotaUsedBytes {
        get {
            ulong t = 0, a = 0;
            _ = Internal.GetQuota(ref t, ref a);
            return t - a;
        }
    }

    /// <summary>
    ///     Number of bytes remaining until your quota is used
    /// </summary>
    public static ulong QuotaRemainingBytes {
        get {
            ulong t = 0, a = 0;
            _ = Internal.GetQuota(ref t, ref a);
            return a;
        }
    }

    /// <summary>
    ///     returns true if IsCloudEnabledForAccount AND IsCloudEnabledForApp
    /// </summary>
    public static bool IsCloudEnabled {
        get { return IsCloudEnabledForAccount && IsCloudEnabledForApp; }
    }

    /// <summary>
    ///     Checks if the account wide Steam Cloud setting is enabled for this user
    ///     or if they disabled it in the Settings->Cloud dialog.
    /// </summary>
    public static bool IsCloudEnabledForAccount {
        get { return Internal.IsCloudEnabledForAccount(); }
    }

    /// <summary>
    ///     Checks if the per game Steam Cloud setting is enabled for this user
    ///     or if they disabled it in the Game Properties->Update dialog.
    ///     This must only ever be set as the direct result of the user explicitly
    ///     requesting that it's enabled or not. This is typically accomplished with
    ///     a checkbox within your in-game options
    /// </summary>
    public static bool IsCloudEnabledForApp {
        get { return Internal.IsCloudEnabledForApp(); }
        set { Internal.SetCloudEnabledForApp(value); }
    }

    /// <summary>
    ///     Gets the total number of local files synchronized by Steam Cloud.
    /// </summary>
    public static int FileCount {
        get { return Internal.GetFileCount(); }
    }

    /// <summary>
    ///     Get a list of filenames synchronized by Steam Cloud
    /// </summary>
    public static IEnumerable<string> Files {
        get {
            var _ = 0;
            for (var i = 0; i < FileCount; i++) {
                var filename = Internal.GetFileNameAndSize(i, ref _);
                yield return filename;
            }
        }
    }

    internal override bool InitializeInterface(bool server) {
        SetInterface(server, new ISteamRemoteStorage(server));
        if (Interface.Self == IntPtr.Zero)
            return false;

        return true;
    }


    /// <summary>
    ///     Creates a new file, writes the bytes to the file, and then closes the file.
    ///     If the target file already exists, it is overwritten
    /// </summary>
    public static unsafe bool FileWrite(string filename, byte[] data) {
        fixed (byte* ptr = data) {
            return Internal.FileWrite(filename, (IntPtr)ptr, data.Length);
        }
    }

    /// <summary>
    ///     Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    public static unsafe byte[] FileRead(string filename) {
        var size = FileSize(filename);
        if (size <= 0)
            return null;
        var buffer = new byte[size];

        fixed (byte* ptr = buffer) {
            var readsize = Internal.FileRead(filename, (IntPtr)ptr, size);
            return buffer;
        }
    }

    /// <summary>
    ///     Checks whether the specified file exists.
    /// </summary>
    public static bool FileExists(string filename) {
        return Internal.FileExists(filename);
    }

    /// <summary>
    ///     Checks if a specific file is persisted in the steam cloud.
    /// </summary>
    public static bool FilePersisted(string filename) {
        return Internal.FilePersisted(filename);
    }

    /// <summary>
    ///     Gets the specified file's last modified date/time.
    /// </summary>
    public static DateTime FileTime(string filename) {
        return Epoch.ToDateTime(Internal.GetFileTimestamp(filename));
    }

    /// <summary>
    ///     Gets the specified files size in bytes. 0 if not exists.
    /// </summary>
    public static int FileSize(string filename) {
        return Internal.GetFileSize(filename);
    }

    /// <summary>
    ///     Deletes the file from remote storage, but leaves it on the local disk and remains accessible from the API.
    /// </summary>
    public static bool FileForget(string filename) {
        return Internal.FileForget(filename);
    }

    /// <summary>
    ///     Deletes a file from the local disk, and propagates that delete to the cloud.
    /// </summary>
    public static bool FileDelete(string filename) {
        return Internal.FileDelete(filename);
    }
}
