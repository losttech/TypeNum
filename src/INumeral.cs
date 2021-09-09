namespace TypeNum {
    using System;
    public interface INumeral {
        int Num { get; }
    }

    public interface INumeral<T> {
        int Num { get; }
    }

    public static class Numeral<T> where T : unmanaged {
        public static Type GetNType(int n) {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
            if (n > PowersOfTwo.Max) throw new NotImplementedException();

            Type result = (n & 1) == 0 ? typeof(N0<T>) : typeof(N1<T>);
            int pwr = 2;
            while (n >= pwr) {
                if ((n & pwr) == pwr) {
                    var powerOfTwo = PowersOfTwo<T>.Get(pwr);
                    result = typeof(Sum<,,>).MakeGenericType(typeof(T), powerOfTwo, result);
                }

                pwr <<= 1;
            }
            return result;
        }
    }
}
