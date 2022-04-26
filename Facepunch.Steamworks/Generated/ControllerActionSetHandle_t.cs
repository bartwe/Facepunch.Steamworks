using System;

namespace Steamworks.Data;

struct ControllerActionSetHandle_t : IEquatable<ControllerActionSetHandle_t>, IComparable<ControllerActionSetHandle_t> {
    // Name: ControllerActionSetHandle_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator ControllerActionSetHandle_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(ControllerActionSetHandle_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((ControllerActionSetHandle_t)p);
    }

    public bool Equals(ControllerActionSetHandle_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(ControllerActionSetHandle_t a, ControllerActionSetHandle_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(ControllerActionSetHandle_t a, ControllerActionSetHandle_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(ControllerActionSetHandle_t other) {
        return Value.CompareTo(other.Value);
    }
}