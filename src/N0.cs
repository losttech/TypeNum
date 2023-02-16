namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    public struct N0 : INumeral { public static int Num => 0; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N0<T> : INumeral<T> where T : unmanaged {
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0;
        }
    }
}
