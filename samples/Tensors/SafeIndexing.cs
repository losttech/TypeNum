using System;
using System.Collections.Generic;
using System.Text;
using static TypeNum.FixedArray;

namespace TypeNum {
    class SafeIndexing<Shape, T> where Shape: unmanaged, INumeral<int> {
        object Get(object key) => throw new NotImplementedException();
        void Set(object key, object value) => throw new NotImplementedException();

        T this[FixedArray<Shape, int> indexes] {
            get => (T)this.Get(indexes);
            set => this.Set(indexes, value);
        }

        static void Sample() {
            var a = new SafeIndexing<N2<int>, float>();
            a[A(1, 2)] = 1.5f;
        }
    }
}
