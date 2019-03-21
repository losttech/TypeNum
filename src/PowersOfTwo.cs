namespace TypeNum {
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct N2<T>: Numeral<T> where T: unmanaged {
        Twice<N1<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N4<T> : Numeral<T> where T : unmanaged {
        Twice<N2<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N8<T> : Numeral<T> where T : unmanaged {
        Twice<N4<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 8;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N16<T> : Numeral<T> where T : unmanaged {
        Twice<N8<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 16;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N32<T> : Numeral<T> where T : unmanaged {
        Twice<N16<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 32;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N64<T> : Numeral<T> where T : unmanaged {
        Twice<N32<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 64;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N128<T> : Numeral<T> where T : unmanaged {
        Twice<N64<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 128;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N256<T> : Numeral<T> where T : unmanaged {
        Twice<N128<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 256;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N512<T> : Numeral<T> where T : unmanaged {
        Twice<N256<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 512;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N1024<T> : Numeral<T> where T : unmanaged {
        Twice<N512<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1024;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N2048<T> : Numeral<T> where T : unmanaged {
        Twice<N1024<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 2048;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct N4096<T> : Numeral<T> where T : unmanaged {
        Twice<N2048<T>, T> data;
        public int Num {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 4096;
        }
    }
}
