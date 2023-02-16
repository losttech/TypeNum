namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    public struct N1 : INumeral { public static int Num => 1; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N1<T> : INumeral<T> where T: unmanaged {
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1;
        }

        public T Value;
    }
}
