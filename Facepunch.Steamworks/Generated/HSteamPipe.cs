using System;

namespace Steamworks.Data;

struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe> {
    // Name: HSteamPipe, Type: int
    public int Value;

    public static implicit operator HSteamPipe(int value) {
        return new() { Value = value };
    }

    public static implicit operator int(HSteamPipe value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((HSteamPipe)p);
    }

    public bool Equals(HSteamPipe p) {
        return p.Value == Value;
    }

    public static bool operator ==(HSteamPipe a, HSteamPipe b) {
        return a.Equals(b);
    }

    public static bool operator !=(HSteamPipe a, HSteamPipe b) {
        return !a.Equals(b);
    }

    public int CompareTo(HSteamPipe other) {
        return Value.CompareTo(other.Value);
    }
}
