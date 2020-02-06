namespace TypeNum {
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct Sum<T1, T2> : Numeral where T1 : struct, Numeral where T2 : struct, Numeral
    {
        static readonly int num = checked(default(T1).Num + default(T2).Num);

        public int Num => num;

        static Sum()
        {
            int n2 = default(T2).Num;
            int n1 = default(T1).Num;
            if (n1 <= n2)
                throw new ArgumentException("Consistency: T1 must always be > T2. Swap them."
                    + $"\n{typeof(Sum<T1, T2>).Name}: {typeof(T1).Name}={n1},{typeof(T2).Name}={n2}");
            var t1 = typeof(T1);
            var t2 = typeof(T2);
            if (t2.IsConstructedGenericType && t2.GetGenericTypeDefinition() == typeof(Sum<,>))
                throw new ArgumentException("Consistency: T2 must not be another Sum<X,Y>. Instead use Sum<Sum<T1, X>, Y>");
            if (t1.IsConstructedGenericType && t1.GetGenericTypeDefinition() == typeof(Sum<,>))
            {
                foreach (var part in t1.GenericTypeArguments)
                    if (((Numeral)Activator.CreateInstance(part)).Num <= n2)
                        throw new ArgumentException("Consistency: in Sum<Sum<A, B>, C> A and B must each be > C");
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Sum<T, T1, T2>: Numeral<T>
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
