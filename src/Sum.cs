namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct Sum<T1, T2> : Numeral where T1 : struct, Numeral where T2 : struct, Numeral
    {
        static readonly int num = checked(default(T1).Num + default(T2).Num);

        public int Num => num;
    }

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
