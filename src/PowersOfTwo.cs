namespace TypeNum {
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct N2 : INumeral { public static int Num => 2; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N2<T> : INumeral<T> where T : unmanaged {
        Twice<N1<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2;
        }
    }

    public struct N4 : INumeral { public static int Num => 4; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N4<T> : INumeral<T> where T : unmanaged {
        Twice<N2<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4;
        }
    }

    public struct N8 : INumeral { public static int Num => 8; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N8<T> : INumeral<T> where T : unmanaged {
        Twice<N4<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 8;
        }
    }

    public struct N16 : INumeral { public static int Num => 16; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N16<T> : INumeral<T> where T : unmanaged {
        Twice<N8<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 16;
        }
    }

    public struct N32 : INumeral { public static int Num => 32; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N32<T> : INumeral<T> where T : unmanaged {
        Twice<N16<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 32;
        }
    }

    public struct N64 : INumeral { public static int Num => 64; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N64<T> : INumeral<T> where T : unmanaged {
        Twice<N32<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 64;
        }
    }

    public struct N128 : INumeral { public static int Num => 128; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N128<T> : INumeral<T> where T : unmanaged {
        Twice<N64<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 128;
        }
    }

    public struct N256 : INumeral { public static int Num => 256; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N256<T> : INumeral<T> where T : unmanaged {
        Twice<N128<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 256;
        }
    }

    public struct N512 : INumeral { public static int Num => 512; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N512<T> : INumeral<T> where T : unmanaged {
        Twice<N256<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 512;
        }
    }

    public struct N1024 : INumeral { public static int Num => 1024; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N1024<T> : INumeral<T> where T : unmanaged {
        Twice<N512<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1024;
        }
    }

    public struct N2048 : INumeral { public static int Num => 2048; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N2048<T> : INumeral<T> where T : unmanaged {
        Twice<N1024<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2048;
        }
    }

    public struct N4096 : INumeral { public static int Num => 4096; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N4096<T> : INumeral<T> where T : unmanaged {
        Twice<N2048<T>, T> data;
        public static int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4096;
        }
    }

    public static class PowersOfTwo {
        public static int Max { get; } = 4096;
    }

    public static class PowersOfTwo<T> where T : unmanaged {
        static readonly Dictionary<int, Type> types = new();
        public static Type Get(int powerOfTwo) {
            if (powerOfTwo < 0) throw new ArgumentOutOfRangeException(nameof(powerOfTwo));
            if (powerOfTwo > PowersOfTwo.Max) throw new NotImplementedException("Too large");
            return types.TryGetValue(powerOfTwo, out var type)
                ? type
                : throw new ArgumentException("Not a power of 2");
        }

        static PowersOfTwo() {
            for (int i = 2; i <= PowersOfTwo.Max; i <<= 1) {
                types[i] = Type.GetType(nameof(TypeNum) + ".N" + i.ToString(System.Globalization.CultureInfo.InvariantCulture) + "`1")!
                    .MakeGenericType(typeof(T));
            }
        }
    }
}
