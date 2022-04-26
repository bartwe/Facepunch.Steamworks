using System;

namespace Steamworks.Data;

struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser> {
    // Name: HSteamUser, Type: int
    public int Value;

    public static implicit operator HSteamUser(int value) {
        return new() { Value = value };
    }

    public static implicit operator int(HSteamUser value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((HSteamUser)p);
    }

    public bool Equals(HSteamUser p) {
        return p.Value == Value;
    }

    public static bool operator ==(HSteamUser a, HSteamUser b) {
        return a.Equals(b);
    }

    public static bool operator !=(HSteamUser a, HSteamUser b) {
        return !a.Equals(b);
    }

    public int CompareTo(HSteamUser other) {
        return Value.CompareTo(other.Value);
    }
}