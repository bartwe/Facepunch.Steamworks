using System;

namespace Steamworks.Data;

struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t> {
    // Name: SteamAPICall_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator SteamAPICall_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(SteamAPICall_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SteamAPICall_t)p);
    }

    public bool Equals(SteamAPICall_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SteamAPICall_t a, SteamAPICall_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SteamAPICall_t a, SteamAPICall_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SteamAPICall_t other) {
        return Value.CompareTo(other.Value);
    }
}
