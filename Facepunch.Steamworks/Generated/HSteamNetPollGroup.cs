using System;

namespace Steamworks.Data;

struct HSteamNetPollGroup : IEquatable<HSteamNetPollGroup>, IComparable<HSteamNetPollGroup> {
    // Name: HSteamNetPollGroup, Type: unsigned int
    public uint Value;

    public static implicit operator HSteamNetPollGroup(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(HSteamNetPollGroup value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((HSteamNetPollGroup)p);
    }

    public bool Equals(HSteamNetPollGroup p) {
        return p.Value == Value;
    }

    public static bool operator ==(HSteamNetPollGroup a, HSteamNetPollGroup b) {
        return a.Equals(b);
    }

    public static bool operator !=(HSteamNetPollGroup a, HSteamNetPollGroup b) {
        return !a.Equals(b);
    }

    public int CompareTo(HSteamNetPollGroup other) {
        return Value.CompareTo(other.Value);
    }
}
