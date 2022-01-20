using System;

namespace Steamworks;

/// <summary>
///     Undocumented Parental Settings
/// </summary>
public sealed class SteamVideo : SteamClientClass<SteamVideo> {
    internal static ISteamVideo Internal => Interface as ISteamVideo;

    /// <summary>
    ///     Return true if currently using Steam's live broadcasting
    /// </summary>
    public static bool IsBroadcasting {
        get {
            var viewers = 0;
            return Internal.IsBroadcasting(ref viewers);
        }
    }

    /// <summary>
    ///     If we're broadcasting, will return the number of live viewers
    /// </summary>
    public static int NumViewers {
        get {
            var viewers = 0;

            if (!Internal.IsBroadcasting(ref viewers))
                return 0;

            return viewers;
        }
    }

    internal override bool InitializeInterface(bool server) {
        SetInterface(server, new ISteamVideo(server));
        if (Interface.Self == IntPtr.Zero)
            return false;

        InstallEvents();

        return true;
    }

    internal static void InstallEvents() { }
}
