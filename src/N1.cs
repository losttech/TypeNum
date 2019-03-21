namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct N1 : Numeral {
        public int Num => 1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N1<T> : Numeral<T>
        where T: unmanaged {
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1;
        }

        public T Value;
    }
}
