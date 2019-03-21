namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Sequential)]
    public struct N0<T> : Numeral<T> where T : unmanaged {
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0;
        }
    }
}
