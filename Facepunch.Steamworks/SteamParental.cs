﻿using System;
using Steamworks.Data;

namespace Steamworks;

/// <summary>
///     Undocumented Parental Settings
/// </summary>
public sealed class SteamParental : SteamSharedClass<SteamParental> {
    internal static ISteamParentalSettings Internal {
        get { return Interface as ISteamParentalSettings; }
    }


    /// <summary>
    /// </summary>
    public static bool IsParentalLockEnabled {
        get { return Internal.BIsParentalLockEnabled(); }
    }

    /// <summary>
    /// </summary>
    public static bool IsParentalLockLocked {
        get { return Internal.BIsParentalLockLocked(); }
    }

    internal override bool InitializeInterface(bool server) {
        SetInterface(server, new ISteamParentalSettings(server));
        if (Interface.Self == IntPtr.Zero)
            return false;

        InstallEvents(server);

        return true;
    }

    internal static void InstallEvents(bool server) {
        Dispatch.Install<SteamParentalSettingsChanged_t>(x => OnSettingsChanged?.Invoke(), server);
    }

    /// <summary>
    ///     Parental Settings Changed
    /// </summary>
    public static event Action OnSettingsChanged;

    /// <summary>
    /// </summary>
    public static bool IsAppBlocked(AppId app) {
        return Internal.BIsAppBlocked(app.Value);
    }

    /// <summary>
    /// </summary>
    public static bool BIsAppInBlockList(AppId app) {
        return Internal.BIsAppInBlockList(app.Value);
    }

    /// <summary>
    /// </summary>
    public static bool IsFeatureBlocked(ParentalFeature feature) {
        return Internal.BIsFeatureBlocked(feature);
    }

    /// <summary>
    /// </summary>
    public static bool BIsFeatureInBlockList(ParentalFeature feature) {
        return Internal.BIsFeatureInBlockList(feature);
    }
}
