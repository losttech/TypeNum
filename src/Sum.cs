namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public readonly struct Sum<T1, T2> : INumeral where T1 : struct, INumeral where T2 : struct, INumeral
    {
        public static int Num { get; } = checked(T1.Num + T2.Num);

        static Sum()
        {
            int n2 = T2.Num;
            int n1 = T1.Num;
            if (n1 <= n2)
                throw new ArgumentException("Consistency: T1 must always be > T2. Swap them."
                    + $"\n{typeof(Sum<T1, T2>).Name}: {typeof(T1).Name}={n1},{typeof(T2).Name}={n2}");
            if (n1 == 0 || n2 == 0)
                throw new ArgumentException("Consistency: T1 and T2 must always be > 0."
                    + $"\n{typeof(Sum<T1, T2>).Name}: {typeof(T1).Name}={n1},{typeof(T2).Name}={n2}");
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            if (t2.IsConstructedGenericType && t2.GetGenericTypeDefinition() == typeof(Sum<,>))
                throw new ArgumentException("Consistency: T2 must not be another Sum<X,Y>. Instead use Sum<Sum<T1, X>, Y>");
            if (t1.IsConstructedGenericType && t1.GetGenericTypeDefinition() == typeof(Sum<,>))
            {
                foreach (var part in t1.GenericTypeArguments) {
                    if (Numeral.GetNum(part) <= n2)
                        throw new ArgumentException("Consistency: in Sum<Sum<A, B>, C> A and B must each be > C");
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Sum<T, T1, T2>: INumeral<T>
        where T1 : struct, INumeral<T>
        where T2 : struct, INumeral<T>
    {
        public T1 Item1;
        public T2 Item2;

        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => T1.Num + T2.Num;
        }

        static Sum() {
            Sum<T1, T2>.Num.GetHashCode();
        }
    }
}
