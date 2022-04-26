using System;

namespace Steamworks.Data;

struct JobID_t : IEquatable<JobID_t>, IComparable<JobID_t> {
    // Name: JobID_t, Type: unsigned long long
    public ulong Value;

    public static implicit operator JobID_t(ulong value) {
        return new() { Value = value };
    }

    public static implicit operator ulong(JobID_t value) {
        return value.Value;
    }

    public override string ToString() {
        return Value.ToString();
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override bool Equals(object p) {
        return Equals((JobID_t)p);
    }

    public bool Equals(JobID_t p) {
        return p.Value == Value;
    }

    public static bool operator ==(JobID_t a, JobID_t b) {
        return a.Equals(b);
    }

    public static bool operator !=(JobID_t a, JobID_t b) {
        return !a.Equals(b);
    }

    public int CompareTo(JobID_t other) {
        return Value.CompareTo(other.Value);
    }
}