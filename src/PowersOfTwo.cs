namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public struct N2 : Numeral { public int Num => 2; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N2<T>: Numeral<T> where T: unmanaged {
        Twice<N1<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2;
        }
    }

    public struct N4 : Numeral { public int Num => 4; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N4<T> : Numeral<T> where T : unmanaged {
        Twice<N2<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4;
        }
    }

    public struct N8 : Numeral { public int Num => 8; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N8<T> : Numeral<T> where T : unmanaged {
        Twice<N4<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 8;
        }
    }

    public struct N16 : Numeral { public int Num => 16; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N16<T> : Numeral<T> where T : unmanaged {
        Twice<N8<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 16;
        }
    }

    public struct N32 : Numeral { public int Num => 32; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N32<T> : Numeral<T> where T : unmanaged {
        Twice<N16<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 32;
        }
    }

    public struct N64 : Numeral { public int Num => 64; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N64<T> : Numeral<T> where T : unmanaged {
        Twice<N32<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 64;
        }
    }

    public struct N128 : Numeral { public int Num => 128; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N128<T> : Numeral<T> where T : unmanaged {
        Twice<N64<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 128;
        }
    }

    public struct N256 : Numeral { public int Num => 256; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N256<T> : Numeral<T> where T : unmanaged {
        Twice<N128<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 256;
        }
    }

    public struct N512 : Numeral { public int Num => 512; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N512<T> : Numeral<T> where T : unmanaged {
        Twice<N256<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 512;
        }
    }

    public struct N1024 : Numeral { public int Num => 1024; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N1024<T> : Numeral<T> where T : unmanaged {
        Twice<N512<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1024;
        }
    }

    public struct N2048 : Numeral { public int Num => 2048; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N2048<T> : Numeral<T> where T : unmanaged {
        Twice<N1024<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2048;
        }
    }

    public struct N4096 : Numeral { public int Num => 4096; }
    [StructLayout(LayoutKind.Sequential)]
    public struct N4096<T> : Numeral<T> where T : unmanaged {
        Twice<N2048<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4096;
        }
    }

    public static class PowersOfTwo
    {
        public static int Max = 4096;
    }
}
