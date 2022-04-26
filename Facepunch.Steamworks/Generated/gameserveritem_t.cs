using System.Runtime.InteropServices;

namespace Steamworks.Data;

partial struct gameserveritem_t {
    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_Construct", CallingConvention = Platform.CC)]
    internal static extern void InternalConstruct(ref gameserveritem_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_GetName", CallingConvention = Platform.CC)]
    internal static extern Utf8StringPointer InternalGetName(ref gameserveritem_t self);

    [DllImport(Platform.LibraryName, EntryPoint = "SteamAPI_gameserveritem_t_SetName", CallingConvention = Platform.CC)]
    internal static extern void InternalSetName(ref gameserveritem_t self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8StringToNative))] string pName);
}
