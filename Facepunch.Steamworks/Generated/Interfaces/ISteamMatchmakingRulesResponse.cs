using System;
using System.Runtime.InteropServices;

namespace Steamworks {
    sealed class ISteamMatchmakingRulesResponse : SteamInterface {
        internal ISteamMatchmakingRulesResponse(bool IsGameServer) {
            SetupInterface(IsGameServer);
        }

    #region FunctionMeta

        [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded", CallingConvention = Platform.CC)]
        static extern void _RulesResponded(
            IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))]
            string pchRule, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))]
            string pchValue
        );

    #endregion

        internal void RulesResponded(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))]
            string pchRule, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))]
            string pchValue
        ) {
            _RulesResponded(Self, pchRule, pchValue);
        }

    #region FunctionMeta

        [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond", CallingConvention = Platform.CC)]
        static extern void _RulesFailedToRespond(IntPtr self);

    #endregion

        internal void RulesFailedToRespond() {
            _RulesFailedToRespond(Self);
        }

    #region FunctionMeta

        [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete", CallingConvention = Platform.CC)]
        static extern void _RulesRefreshComplete(IntPtr self);

    #endregion

        internal void RulesRefreshComplete() {
            _RulesRefreshComplete(Self);
        }
    }
}
