﻿using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.PixelFormats;

namespace SnapX.Core.SharpCapture.Windows;

public partial struct DirectXHalfVector4 : IPixel<DirectXHalfVector4>, IPackedVector<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DirectXHalfVector4"/> struct.
    /// </summary>
    /// <param name="x">The x-component.</param>
    /// <param name="y">The y-component.</param>
    /// <param name="z">The z-component.</param>
    /// <param name="w">The w-component.</param>
    public DirectXHalfVector4(float x, float y, float z, float w)
        : this(new Vector4(x, y, z, w))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectXHalfVector4"/> struct.
    /// </summary>
    /// <param name="vector">A vector containing the initial values for the components</param>
    public DirectXHalfVector4(Vector4 vector) => this.PackedValue = Pack(ref vector);

    /// <inheritdoc/>
    public ulong PackedValue { get; set; }

    /// <summary>
    /// Compares two <see cref="DirectXHalfVector4"/> objects for equality.
    /// </summary>
    /// <param name="left">The <see cref="DirectXHalfVector4"/> on the left side of the operand.</param>
    /// <param name="right">The <see cref="DirectXHalfVector4"/> on the right side of the operand.</param>
    /// <returns>
    /// True if the <paramref name="left"/> parameter is equal to the <paramref name="right"/> parameter; otherwise, false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(DirectXHalfVector4 left, DirectXHalfVector4 right) => left.Equals(right);

    /// <summary>
    /// Compares two <see cref="DirectXHalfVector4"/> objects for equality.
    /// </summary>
    /// <param name="left">The <see cref="DirectXHalfVector4"/> on the left side of the operand.</param>
    /// <param name="right">The <see cref="DirectXHalfVector4"/> on the right side of the operand.</param>
    /// <returns>
    /// True if the <paramref name="left"/> parameter is not equal to the <paramref name="right"/> parameter; otherwise, false.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(DirectXHalfVector4 left, DirectXHalfVector4 right) => !left.Equals(right);

    /// <inheritdoc />
    public readonly PixelOperations<DirectXHalfVector4> CreatePixelOperations() => new();

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromScaledVector4(Vector4 vector)
    {
        FromVector4(vector);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Vector4 ToScaledVector4()
    {
        return ToVector4();
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromVector4(Vector4 vector) => this.PackedValue = Pack(ref vector);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Vector4 ToVector4() => new(
        (float)BitConverter.UInt16BitsToHalf((ushort)this.PackedValue),
        (float)BitConverter.UInt16BitsToHalf((ushort)(this.PackedValue >> 0x10)),
        (float)BitConverter.UInt16BitsToHalf((ushort)(this.PackedValue >> 0x20)),
        (float)BitConverter.UInt16BitsToHalf((ushort)(this.PackedValue >> 0x30)));

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromArgb32(Argb32 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromBgr24(Bgr24 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromBgra32(Bgra32 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromAbgr32(Abgr32 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromBgra5551(Bgra5551 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromL8(L8 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromL16(L16 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromLa16(La16 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromLa32(La32 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromRgb24(Rgb24 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromRgba32(Rgba32 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ToRgba32(ref Rgba32 dest) => dest.FromScaledVector4(this.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromRgb48(Rgb48 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void FromRgba64(Rgba64 source) => this.FromScaledVector4(source.ToScaledVector4());

    /// <inheritdoc />
    public override readonly bool Equals(object? obj) => obj is DirectXHalfVector4 other && this.Equals(other);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(DirectXHalfVector4 other) => this.PackedValue.Equals(other.PackedValue);

    /// <inheritdoc />
    public override readonly string ToString()
    {
        var vector = this.ToVector4();
        return FormattableString.Invariant($"DirectXHalfVector4({vector.X:#0.##}, {vector.Y:#0.##}, {vector.Z:#0.##}, {vector.W:#0.##})");
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly int GetHashCode() => this.PackedValue.GetHashCode();

    /// <summary>
    /// Packs a <see cref="Vector4"/> into a <see cref="ulong"/>.
    /// </summary>
    /// <param name="vector">The vector containing the values to pack.</param>
    /// <returns>The <see cref="ulong"/> containing the packed values.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong Pack(ref Vector4 vector)
    {
        ulong num4 = BitConverter.HalfToUInt16Bits((Half)vector.X);
        ulong num3 = (ulong)BitConverter.HalfToUInt16Bits((Half)vector.Y) << 0x10;
        ulong num2 = (ulong)BitConverter.HalfToUInt16Bits((Half)vector.Z) << 0x20;
        ulong num1 = (ulong)BitConverter.HalfToUInt16Bits((Half)vector.W) << 0x30;
        return num4 | num3 | num2 | num1;
    }
}
