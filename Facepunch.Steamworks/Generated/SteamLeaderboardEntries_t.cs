using System;

namespace Steamworks.Data;

struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t> {
    // Name: SteamLeaderboardEntries_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator SteamLeaderboardEntries_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(SteamLeaderboardEntries_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SteamLeaderboardEntries_t)p);
    }

    public bool Equals(SteamLeaderboardEntries_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SteamLeaderboardEntries_t other) {
        return Value.CompareTo(other.Value);
    }
}
