namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public readonly struct Twice<T>: INumeral
        where T: struct, INumeral
    {
        public static int Num { get; } = checked(T.Num * 2);

        static Twice()
        {
            if (typeof(T) != typeof(N4096)
                && (!typeof(T).IsConstructedGenericType || typeof(T).GetGenericTypeDefinition() != typeof(Twice<>)))
                throw new ArgumentException("Consistency: T must be either PowersOfTwo.Max or Twice<something>");
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Twice<TNum, T> : INumeral<T>
        where TNum: unmanaged, INumeral<T>
    {
        public TNum Item1;
        public TNum Item2;

        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => TNum.Num * 2;
        }
    }
}
