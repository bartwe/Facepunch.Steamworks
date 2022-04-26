using System;

namespace Steamworks.Data;

struct BREAKPAD_HANDLE : IEquatable<BREAKPAD_HANDLE>, IComparable<BREAKPAD_HANDLE> {
    // Name: BREAKPAD_HANDLE, Type: void *
    public IntPtr Value;

    public static implicit operator BREAKPAD_HANDLE(IntPtr value) {
        return new() { Value = value };
    }

    public static implicit operator IntPtr(BREAKPAD_HANDLE value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((BREAKPAD_HANDLE)p);
    }

    public bool Equals(BREAKPAD_HANDLE p) {
        return p.Value == Value;
    }

    public static bool operator ==(BREAKPAD_HANDLE a, BREAKPAD_HANDLE b) {
        return a.Equals(b);
    }

    public static bool operator !=(BREAKPAD_HANDLE a, BREAKPAD_HANDLE b) {
        return !a.Equals(b);
    }

    public int CompareTo(BREAKPAD_HANDLE other) {
        return Value.ToInt64().CompareTo(other.Value.ToInt64());
    }
}