using System;

namespace Steamworks.Data;

struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t> {
    // Name: FriendsGroupID_t, Type: short
    public short Value;

    public static implicit operator FriendsGroupID_t(short value) {
        return new() { Value = value };
    }

    public static implicit operator short(FriendsGroupID_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((FriendsGroupID_t)p);
    }

    public bool Equals(FriendsGroupID_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(FriendsGroupID_t a, FriendsGroupID_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(FriendsGroupID_t a, FriendsGroupID_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(FriendsGroupID_t other) {
        return Value.CompareTo(other.Value);
    }
}
