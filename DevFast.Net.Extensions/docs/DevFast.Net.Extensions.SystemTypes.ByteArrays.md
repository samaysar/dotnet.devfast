#### [DevFast.Net.Extensions](index.md 'index')
### [DevFast.Net.Extensions.SystemTypes](DevFast.Net.Extensions.SystemTypes.md 'DevFast.Net.Extensions.SystemTypes')

## ByteArrays Class

Extension methods on Array of type [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte').

```csharp
public static class ByteArrays
```
- *Methods*
  - **[CopyToSafe(this byte[], byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int)')**
  - **[CopyToUnSafe(this byte[], byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int)')**
  - **[DoubleByteCapacity(this byte[])](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(thisbyte[]) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(this byte[])')**
  - **[EnsureByteCapacity(byte[], int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[],int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[], int)')**
  - **[EnsureByteCapacity(this byte[], int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(thisbyte[],int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(this byte[], int)')**
  - **[LiftNCopySafe(this byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(this byte[], int, int, int)')**
  - **[LiftNCopyUnSafe(this byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int)')**

## ByteArrays Class

Extension methods on Array of type [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte').

```csharp
public static class ByteArrays
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ByteArrays
### Methods

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int)'></a>

## ByteArrays.CopyToSafe(this byte[], byte[], int, int, int) Method

Copies [total](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).total 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int).total') bytes of [source](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).source 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int).source') array starting from 
[sourcePosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).sourcePosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int).sourcePosition') (included) to [target](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).target 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int).target') array's
[targetPosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).targetPosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int).targetPosition') (included) and onwards.

This method is SAFE version of [CopyToUnSafe(this byte[], byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int)') 
as constraint are checked.

```csharp
public static void CopyToSafe(this byte[] source, byte[] target, int sourcePosition, int total, int targetPosition);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).source'></a>

`source` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).target'></a>

`target` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Target array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).sourcePosition'></a>

`sourcePosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position in source array to start copying byte from.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).total'></a>

`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Total number of bytes to copy.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int).targetPosition'></a>

`targetPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position in target array to start writing the bytes to.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int)'></a>

## ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int) Method

Copies [total](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).total 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int).total') bytes of [source](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).source 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int).source') array starting from 
[sourcePosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).sourcePosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int).sourcePosition') (included) to [target](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).target 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int).target') array's
[targetPosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).targetPosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(this byte[], byte[], int, int, int).targetPosition') (included) and onwards.

!!!- CALL IT AT YOUR OWN RISK -!!!

This method is UNSAFE version of [CopyToSafe(this byte[], byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(thisbyte[],byte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToSafe(this byte[], byte[], int, int, int)') 
as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.

```csharp
public static void CopyToUnSafe(this byte[] source, byte[] target, int sourcePosition, int total, int targetPosition);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).source'></a>

`source` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).target'></a>

`target` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Target array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).sourcePosition'></a>

`sourcePosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position in source array to start copying byte from.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).total'></a>

`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Total number of bytes to copy.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.CopyToUnSafe(thisbyte[],byte[],int,int,int).targetPosition'></a>

`targetPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position in target array to start writing the bytes to.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(thisbyte[])'></a>

## ByteArrays.DoubleByteCapacity(this byte[]) Method

Creates a new array with double the size. Copies the content of [source](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(thisbyte[]).source 'DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(this byte[]).source') to the newly created array.

```csharp
public static byte[] DoubleByteCapacity(this byte[] source);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.DoubleByteCapacity(thisbyte[]).source'></a>

`source` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[],int)'></a>

## ByteArrays.EnsureByteCapacity(byte[], int) Method

Checks if array needs to be resized. When resize takes place, the content of [source](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[],int).source 'DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[], int).source')
are copied to the newly created array.

```csharp
public static void EnsureByteCapacity(ref byte[] source, int capacity);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[],int).source'></a>

`source` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(byte[],int).capacity'></a>

`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Minimum length of the array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(thisbyte[],int)'></a>

## ByteArrays.EnsureByteCapacity(this byte[], int) Method

Checks if array needs to be up-sized. When resize takes place, the content of [source](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(thisbyte[],int).source 'DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(this byte[], int).source')
are copied to the newly created array.

```csharp
public static byte[] EnsureByteCapacity(this byte[] source, int capacity);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(thisbyte[],int).source'></a>

`source` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.EnsureByteCapacity(thisbyte[],int).capacity'></a>

`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Minimum length of the array

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int)'></a>

## ByteArrays.LiftNCopySafe(this byte[], int, int, int) Method

Copies [total](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).total 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(this byte[], int, int, int).total') bytes starting from [sourcePosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).sourcePosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(this byte[], int, int, int).sourcePosition') (included) 
to [targetPosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).targetPosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(this byte[], int, int, int).targetPosition') (Included) and onwards.

NOTE: This method is SAFE version of [LiftNCopyUnSafe(this byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int)') as
constraint are checked.

```csharp
public static void LiftNCopySafe(this byte[] bytes, int sourcePosition, int total, int targetPosition);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).bytes'></a>

`bytes` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).sourcePosition'></a>

`sourcePosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position from which to start copying bytes.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).total'></a>

`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Total number of bytes to copy.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int).targetPosition'></a>

`targetPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position at which starting writing the bytes.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int)'></a>

## ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int) Method

Copies [total](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).total 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int).total') bytes starting from [sourcePosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).sourcePosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int).sourcePosition') (included) 
to [targetPosition](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).targetPosition 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(this byte[], int, int, int).targetPosition') (Included) and onwards.

!!!- CALL IT AT YOUR OWN RISK -!!!

This method is UNSAFE version of [LiftNCopySafe(this byte[], int, int, int)](DevFast.Net.Extensions.SystemTypes.ByteArrays.md#DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(thisbyte[],int,int,int) 'DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopySafe(this byte[], int, int, int)') 
as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.

```csharp
public static void LiftNCopyUnSafe(this byte[] bytes, int sourcePosition, int total, int targetPosition);
```
#### Parameters

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).bytes'></a>

`bytes` [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Source array.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).sourcePosition'></a>

`sourcePosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position from which to start copying bytes.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).total'></a>

`total` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Total number of bytes to copy.

<a name='DevFast.Net.Extensions.SystemTypes.ByteArrays.LiftNCopyUnSafe(thisbyte[],int,int,int).targetPosition'></a>

`targetPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Position at which starting writing the bytes.