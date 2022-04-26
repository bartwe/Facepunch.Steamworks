using System;

namespace Steamworks.Data;

struct RTime32 : IEquatable<RTime32>, IComparable<RTime32> {
    // Name: RTime32, Type: unsigned int
    public uint Value;

    public static implicit operator RTime32(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(RTime32 value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((RTime32)p);
    }

    public bool Equals(RTime32 p) {
        return p.Value == Value;
    }

    public static bool operator ==(RTime32 a, RTime32 b) {
        return a.Equals(b);
    }

    public static bool operator !=(RTime32 a, RTime32 b) {
        return !a.Equals(b);
    }

    public int CompareTo(RTime32 other) {
        return Value.CompareTo(other.Value);
    }
}