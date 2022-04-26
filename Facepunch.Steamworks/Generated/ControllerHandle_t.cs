using System;

namespace Steamworks.Data;

struct ControllerHandle_t : IEquatable<ControllerHandle_t>, IComparable<ControllerHandle_t> {
    // Name: ControllerHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator ControllerHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(ControllerHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((ControllerHandle_t)p);
    }

    public bool Equals(ControllerHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(ControllerHandle_t a, ControllerHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(ControllerHandle_t a, ControllerHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(ControllerHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}