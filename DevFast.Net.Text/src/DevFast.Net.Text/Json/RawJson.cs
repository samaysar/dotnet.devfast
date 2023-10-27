﻿namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Raw JSON output that provide a valid <see cref="JsonType"/> and corresponding
    /// <see cref="Value"/>.
    /// <para>
    /// When <see cref="Type"/> is <see cref="JsonType.Nothing"/>, <see cref="Value"/> is
    /// an empty <see cref="byte"/> array.
    /// </para>
    /// </summary>
    public readonly struct RawJson : IEquatable<RawJson>
    {
        /// <summary>
        /// Create an instance with JSON <paramref name="type"/> and corresponding raw <paramref name="value"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public RawJson(JsonType type, byte[] value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// JSON type of of raw <see cref="Value"/>.
        /// </summary>
        public JsonType Type { get; }

        /// <summary>
        /// Raw JSON value. When <see cref="Type"/> is <see cref="JsonType.Nothing"/>, <see cref="Value"/> is
        /// an empty <see cref="byte"/> array.
        /// </summary>
#pragma warning disable CA1819
        public byte[] Value { get; }
#pragma warning restore CA1819

        /// <summary>
        /// Indicates if provided <paramref name="obj"/> instance is equal to current instance.
        /// </summary>
        /// <param name="obj">Another instance</param>
        public override bool Equals(object? obj)
        {
            return obj is RawJson other && Equals(other);
        }

        /// <summary>
        /// Returns hashcode of current instance.
        /// </summary>
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator to compare 2 instances.
        /// </summary>
        /// <param name="left">Instance left to the operator</param>
        /// <param name="right">Instance right to the operator</param>
        public static bool operator ==(RawJson left, RawJson right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operation to compare 2 instances.
        /// </summary>
        /// <param name="left">Instance left to the operator</param>
        /// <param name="right">Instance right to the operator</param>
        public static bool operator !=(RawJson left, RawJson right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Indicates if provided <paramref name="other"/> instance is equal to current instance.
        /// </summary>
        /// <param name="other">Another instance</param>
        public bool Equals(RawJson other)
        {
            //We dont care if Value array is byte by byte same
            //if it is NOT same Value instance, we say they are not equal.
            return Type.Equals(other.Type) && ReferenceEquals(Value, other.Value);
        }
    }
}