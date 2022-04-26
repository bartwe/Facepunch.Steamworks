using System.Runtime.InteropServices;

namespace Steamworks;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct DigitalState {
    [MarshalAs(UnmanagedType.I1)]
    internal byte BState; // bState byte

    [MarshalAs(UnmanagedType.I1)]
    internal byte BActive; // bActive byte

    public bool Pressed => BState != 0;

    public bool Active => BActive != 0;
}