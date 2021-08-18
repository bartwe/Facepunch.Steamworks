using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks {
    static class SteamAPI {
        internal static bool Init() {
            return Native.SteamAPI_Init();
        }

        internal static void Shutdown() {
            Native.SteamAPI_Shutdown();
        }

        internal static HSteamPipe GetHSteamPipe() {
            return Native.SteamAPI_GetHSteamPipe();
        }

        internal static bool RestartAppIfNecessary(uint unOwnAppID) {
            return Native.SteamAPI_RestartAppIfNecessary(unOwnAppID);
        }

        internal static class Native {
            [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_Init", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SteamAPI_Init();

            [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_Shutdown", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SteamAPI_Shutdown();

            [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_GetHSteamPipe", CallingConvention = CallingConvention.Cdecl)]
            public static extern HSteamPipe SteamAPI_GetHSteamPipe();

            [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_RestartAppIfNecessary", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            public static extern bool SteamAPI_RestartAppIfNecessary(uint unOwnAppID);
        }
    }
}
