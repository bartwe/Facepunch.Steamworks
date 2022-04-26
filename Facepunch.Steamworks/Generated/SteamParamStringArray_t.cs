using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data;

[StructLayout(LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize)]
struct SteamParamStringArray_t {
    internal IntPtr Strings; // m_ppStrings const char **
    internal int NumStrings; // m_nNumStrings int32
}