using System.Runtime.InteropServices;

namespace Steamworks;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct MotionState {
    public float RotQuatX; // rotQuatX float
    public float RotQuatY; // rotQuatY float
    public float RotQuatZ; // rotQuatZ float
    public float RotQuatW; // rotQuatW float
    public float PosAccelX; // posAccelX float
    public float PosAccelY; // posAccelY float
    public float PosAccelZ; // posAccelZ float
    public float RotVelX; // rotVelX float
    public float RotVelY; // rotVelY float
    public float RotVelZ; // rotVelZ float
}