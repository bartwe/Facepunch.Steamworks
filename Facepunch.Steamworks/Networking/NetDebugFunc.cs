using System;
using System.Runtime.InteropServices;

namespace Steamworks;

[UnmanagedFunctionPointer(Platform.CC)]
delegate void NetDebugFunc([In] NetDebugOutput nType, [In] IntPtr pszMsg);