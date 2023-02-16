namespace TypeNum {
    using System;

    using Xunit;
    public class NumeralTests {
        [Fact]
        public void GetNumeralType() {
            var n5int = Numeral<int>.GetNType(5);
            Assert.Equal(typeof(Sum<int, N4<int>, N1<int>>), n5int);
        }

        [Fact]
        public void Sum0_Prohibited() {
            Assert.Throws<TypeInitializationException>(() => Sum<int, N2<int>, N0<int>>.Num.GetHashCode());
        }
    }
}
