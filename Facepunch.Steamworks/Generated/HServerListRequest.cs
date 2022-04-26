using System;

namespace Steamworks.Data;

struct HServerListRequest : IEquatable<HServerListRequest>, IComparable<HServerListRequest> {
    // Name: HServerListRequest, Type: void *
    public IntPtr Value;

    public static implicit operator HServerListRequest(IntPtr value) {
        return new() { Value = value };
    }

    public static implicit operator IntPtr(HServerListRequest value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((HServerListRequest)p);
    }

    public bool Equals(HServerListRequest p) {
        return p.Value == Value;
    }

    public static bool operator ==(HServerListRequest a, HServerListRequest b) {
        return a.Equals(b);
    }

    public static bool operator !=(HServerListRequest a, HServerListRequest b) {
        return !a.Equals(b);
    }

    public int CompareTo(HServerListRequest other) {
        return Value.ToInt64().CompareTo(other.Value.ToInt64());
    }
}