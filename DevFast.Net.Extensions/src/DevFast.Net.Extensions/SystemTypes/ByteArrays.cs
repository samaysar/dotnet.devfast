namespace DevFast.Net.Extensions.SystemTypes
{
    /// <summary>
    /// Extension methods on Array of type <see cref="byte"/>.
    /// </summary>
    public static class ByteArrays
    {
        /// <summary>
        /// Copies <paramref name="total"/> bytes starting from <paramref name="sourcePosition"/> (included) 
        /// to <paramref name="targetPosition"/> (Included) and onwards.
        /// <para>
        /// NOTE: This method is SAFE version of <see cref="LiftNCopyUnSafe(byte[], int, int, int)"/> as
        /// constraint are checked.
        /// </para>
        /// </summary>
        /// <param name="bytes">Source array.</param>
        /// <param name="sourcePosition">Position from which to start copying bytes.</param>
        /// <param name="total">Total number of bytes to copy.</param>
        /// <param name="targetPosition">Position at which starting writing the bytes.</param>
        public static void LiftNCopySafe(this byte[] bytes, int sourcePosition, int total, int targetPosition)
        {
            if (sourcePosition + total > bytes.Length)
                throw new ArgumentException($"Source position breaches length {bytes.Length}");
            if (targetPosition + total > bytes.Length)
                throw new ArgumentException($"Target position breaches length {bytes.Length}");
            bytes.LiftNCopyUnSafe(sourcePosition, total, targetPosition);
        }

        /// <summary>
        /// Copies <paramref name="total"/> bytes starting from <paramref name="sourcePosition"/> (included) 
        /// to <paramref name="targetPosition"/> (Included) and onwards.
        /// <para>
        /// !!!- CALL IT AT YOUR OWN RISK -!!!
        /// </para>
        /// <para>
        /// This method is UNSAFE version of <see cref="LiftNCopySafe(byte[], int, int, int)"/> 
        /// as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.
        /// </para>
        /// </summary>
        /// <param name="bytes">Source array.</param>
        /// <param name="sourcePosition">Position from which to start copying bytes.</param>
        /// <param name="total">Total number of bytes to copy.</param>
        /// <param name="targetPosition">Position at which starting writing the bytes.</param>
        public static void LiftNCopyUnSafe(this byte[] bytes, int sourcePosition, int total, int targetPosition)
        {
            bytes.LiftNShiftInternal(bytes, sourcePosition, total, targetPosition);
        }

        /// <summary>
        /// Creates a new array with double the size. Copies the content of <paramref name="source"/> to the newly created array.
        /// </summary>
        /// <param name="source">Source array</param>
        public static byte[] DoubleByteCapacity(this byte[] source)
        {
            return source.EnsureByteCapacity(source.Length * 2);
        }

        /// <summary>
        /// Checks if array needs to be up-sized. When resize takes place, the content of <paramref name="source"/>
        /// are copied to the newly created array.
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="capacity">Minimum length of the array</param>
        public static byte[] EnsureByteCapacity(this byte[] source, int capacity)
        {
            EnsureByteCapacity(ref source, capacity);
            return source;
        }

        /// <summary>
        /// Checks if array needs to be resized. When resize takes place, the content of <paramref name="source"/>
        /// are copied to the newly created array.
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="capacity">Minimum length of the array</param>
        public static void EnsureByteCapacity(ref byte[] source, int capacity)
        {
            if (capacity <= source.Length) return;
            var target = new byte[capacity];
            source.LiftNShiftInternal(target, 0, source.Length, 0);
            source = target;
        }

        /// <summary>
        /// Copies <paramref name="total"/> bytes of <paramref name="source"/> array starting from 
        /// <paramref name="sourcePosition"/> (included) to <paramref name="target"/> array's
        /// <paramref name="targetPosition"/> (included) and onwards.
        /// <para>
        /// This method is SAFE version of <see cref="CopyToUnSafe(byte[], byte[], int, int, int)"/> 
        /// as constraint are checked.
        /// </para>
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="target">Target array</param>
        /// <param name="sourcePosition">Position in source array to start copying byte from.</param>
        /// <param name="total">Total number of bytes to copy.</param>
        /// <param name="targetPosition">Position in target array to start writing the bytes to.</param>
        public static void CopyToSafe(this byte[] source, byte[] target, int sourcePosition, int total, int targetPosition)
        {
            if (sourcePosition + total > source.Length)
                throw new ArgumentException($"Source position breaches length {source.Length}");
            if (targetPosition + total > target.Length)
                throw new ArgumentException($"Target position breaches length {target.Length}");
            source.CopyToUnSafe(target, sourcePosition, total, targetPosition);
        }

        /// <summary>
        /// Copies <paramref name="total"/> bytes of <paramref name="source"/> array starting from 
        /// <paramref name="sourcePosition"/> (included) to <paramref name="target"/> array's
        /// <paramref name="targetPosition"/> (included) and onwards.
        /// <para>
        /// !!!- CALL IT AT YOUR OWN RISK -!!!
        /// </para>
        /// <para>
        /// This method is UNSAFE version of <see cref="CopyToSafe(byte[], byte[], int, int, int)"/> 
        /// as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.
        /// </para>
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="target">Target array</param>
        /// <param name="sourcePosition">Position in source array to start copying byte from.</param>
        /// <param name="total">Total number of bytes to copy.</param>
        /// <param name="targetPosition">Position in target array to start writing the bytes to.</param>
        public static void CopyToUnSafe(this byte[] source, byte[] target, int sourcePosition, int total, int targetPosition)
        {
            source.LiftNShiftInternal(target, sourcePosition, total, targetPosition);
        }

        private static void LiftNShiftInternal(this byte[] source, byte[] target, int sourcePosition, int total, int targetPosition)
        {
            unsafe
            {
                fixed (byte* s = &source[sourcePosition])
                fixed (byte* d = &target[targetPosition])
                {
                    Buffer.MemoryCopy(s, d, target.Length - targetPosition, total);
                }
            }
        }
    }
}