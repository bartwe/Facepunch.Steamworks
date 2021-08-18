using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks {
    static class SteamGameServer {
        internal static void RunCallbacks() {
            Native.SteamGameServer_RunCallbacks();
        }

        internal static void Shutdown() {
            Native.SteamGameServer_Shutdown();
        }

        internal static HSteamPipe GetHSteamPipe() {
            return Native.SteamGameServer_GetHSteamPipe();
        }

        internal static class Native {
            [DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SteamGameServer_RunCallbacks();

            [DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_Shutdown", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SteamGameServer_Shutdown();

            [DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_GetHSteamPipe", CallingConvention = CallingConvention.Cdecl)]
            public static extern HSteamPipe SteamGameServer_GetHSteamPipe();
        }
    }
}
