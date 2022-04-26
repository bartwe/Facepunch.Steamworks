using System;

namespace Steamworks.Data;

struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t> {
    // Name: SteamLeaderboard_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator SteamLeaderboard_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(SteamLeaderboard_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((SteamLeaderboard_t)p);
    }

    public bool Equals(SteamLeaderboard_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(SteamLeaderboard_t a, SteamLeaderboard_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(SteamLeaderboard_t a, SteamLeaderboard_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(SteamLeaderboard_t other) {
        return Value.CompareTo(other.Value);
    }
}
