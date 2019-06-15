namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct Twice<T>: Numeral
        where T: struct, Numeral
    {
        static readonly int num = checked(default(T).Num * 2);

        public int Num => num;

        static Twice()
        {
            if (typeof(T) != typeof(N4096)
                && (!typeof(T).IsConstructedGenericType || typeof(T).GetGenericTypeDefinition() != typeof(Twice<>)))
                throw new ArgumentException("Consistency: T must be either PowersOfTwo.Max or Twice<something>");
        }
    }

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
