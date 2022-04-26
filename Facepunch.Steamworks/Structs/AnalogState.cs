using System.Runtime.InteropServices;

namespace Steamworks;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AnalogState {
    public InputSourceMode EMode; // eMode EInputSourceMode
    public float X; // x float
    public float Y; // y float
    internal byte BActive; // bActive byte

    public bool Active => BActive != 0;
}
