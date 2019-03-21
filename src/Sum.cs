namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Sum<T1, T2> where T1 : Numeral where T2: Numeral {}

    [StructLayout(LayoutKind.Sequential)]
    public class Sum<T, T1, T2>: Numeral<T>
        where T1 : struct, Numeral<T>
        where T2 : struct, Numeral<T>
    {
        public T1 Item1;
        public T2 Item2;

        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.Item1.Num + this.Item2.Num;
        }
    }
}
