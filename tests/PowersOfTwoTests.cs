namespace TypeNum.Tests {
    using System;
    using System.Linq;
    using Xunit;
    using static System.FormattableString;
    public class PowersOfTwoTests {
        [Fact]
        public void NumsAreCorrect() {
            int num = default(N4096<int>).Num;

            Assert.Equal(expected: PowersOfTwo.Max, num);
        }

        [Fact]
        public unsafe void SizesAreCorrect() {
            int size = sizeof(N4096<byte>);

            Assert.Equal(expected: PowersOfTwo.Max, size);
        }

        [Fact]
        public void PureNumeralsAreCorrect() {
            string ns = typeof(N0).Namespace;
            var numerals = Enumerable.Range(1, int.MaxValue)
                .Select(i => 1 << i)
                .Prepend(0)
                .TakeWhile(n => n <= PowersOfTwo.Max);
            foreach(int n in numerals)
            {
                string typeName = Invariant($"{ns}.N{n}");
                var numeral = typeof(N0).Assembly.GetType(typeName);
                var instance = (Numeral)Activator.CreateInstance(numeral);
                Assert.Equal(instance.Num, n);
            }
        }
    }
}
