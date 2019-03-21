namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Twice<TNum, T> : Numeral<T>
        where TNum: unmanaged, Numeral<T>
    {
        public TNum Item1;
        public TNum Item2;

        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.Item1.Num * 2;
        }
    }
}
