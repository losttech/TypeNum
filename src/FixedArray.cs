﻿namespace TypeNum {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FixedArray<TSize, T>: IList<T>
        where TSize: unmanaged, Numeral<T>
        where T: unmanaged
    {
        public static int ElementCount {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        TSize value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void CheckIndex(int index) {
            if (index < 0 || index >= ElementCount)
                throw new IndexOutOfRangeException();
        }

        public unsafe T this[int index] {
            get {
                CheckIndex(index);
                fixed (TSize* self = &this.value) {
                    T* data = (T*)self;
                    return data[index];
                }
            }
            set {
                CheckIndex(index);
                fixed (TSize* self = &this.value) {
                    T* data = (T*)self;
                    data[index] = value;
                }
            }
        }

        public int Count {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ElementCount;
        }
        public bool IsReadOnly => false;

        public bool Contains(T item) => this.IndexOf(item) >= 0;

        public unsafe void CopyTo(T[] array, int targetIndex) {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (targetIndex < 0 || (long)targetIndex + ElementCount > array.Length)
                throw new ArgumentOutOfRangeException(paramName: nameof(targetIndex));
            fixed(T* dest = array)
            fixed (TSize* self = &this.value)
                Buffer.MemoryCopy(source: self, dest + targetIndex, array.Length - targetIndex, ElementCount);
        }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < ElementCount; i++)
                yield return this[i];
        }
        public unsafe int IndexOf(T item) {
            fixed (TSize* self = &this.value) {
                T* data = (T*)self;
                for (int i = 0; i < ElementCount; i++)
                    if (object.Equals(data[i], item))
                        return i;
            }

            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        #region Unsupported
        public void Add(T item) => throw new NotSupportedException();
        public void Clear() => throw new NotSupportedException();
        public void Insert(int index, T item) => throw new NotSupportedException();
        public bool Remove(T item) => throw new NotSupportedException();
        public void RemoveAt(int index) => throw new NotSupportedException();
        #endregion

        static FixedArray() {
            ElementCount = default(TSize).Num;
        }
    }

    public static class FixedArray {
        public static FixedArray<N1<T>, T> A<T>(T item0) where T: unmanaged
            => new FixedArray<N1<T>, T> { [0] = item0 };
        public static FixedArray<N2<T>, T> A<T>(T item0, T item1) where T : unmanaged
            => new FixedArray<N2<T>, T> { [0] = item0, [1] = item1 };
        public static FixedArray<Sum<T, N2<T>, N1<T>>, T> A<T>(T item0, T item1, T item2) where T : unmanaged
            => new FixedArray<Sum<T, N2<T>, N1<T>>, T> { [0] = item0, [1] = item1, [2] = item2 };
        public static FixedArray<N4<T>, T> A<T>(T item0, T item1, T item2, T item3) where T : unmanaged
            => new FixedArray<N4<T>, T> { [0] = item0, [1] = item1, [2] = item2, [3] = item3 };
    }
}
