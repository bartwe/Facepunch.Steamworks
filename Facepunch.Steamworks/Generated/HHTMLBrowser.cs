using System;

namespace Steamworks.Data;

struct HHTMLBrowser : IEquatable<HHTMLBrowser>, IComparable<HHTMLBrowser> {
    // Name: HHTMLBrowser, Type: unsigned int
    public uint Value;

    public static implicit operator HHTMLBrowser(uint value) {
        return new() { Value = value };
    }

    public static implicit operator uint(HHTMLBrowser value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((HHTMLBrowser)p);
    }

    public bool Equals(HHTMLBrowser p) {
        return p.Value == Value;
    }

    public static bool operator ==(HHTMLBrowser a, HHTMLBrowser b) {
        return a.Equals(b);
    }

    public static bool operator !=(HHTMLBrowser a, HHTMLBrowser b) {
        return !a.Equals(b);
    }

    public int CompareTo(HHTMLBrowser other) {
        return Value.CompareTo(other.Value);
    }
}
