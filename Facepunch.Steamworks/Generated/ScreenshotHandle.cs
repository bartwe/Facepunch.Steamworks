using System;

namespace Steamworks.Data;

struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle> {
    // Name: ScreenshotHandle, Type: unsigned int
    public uint Value;

    public static implicit operator ScreenshotHandle(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(ScreenshotHandle value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((ScreenshotHandle)p);
    }

    public bool Equals(ScreenshotHandle p) {
        return p.Value == Value;
    }

    public static bool operator ==(ScreenshotHandle a, ScreenshotHandle b) {
        return a.Equals(b);
    }

    public static bool operator !=(ScreenshotHandle a, ScreenshotHandle b) {
        return !a.Equals(b);
    }

    public int CompareTo(ScreenshotHandle other) {
        return Value.CompareTo(other.Value);
    }
}
