namespace TypeNum.Tests {
    using System;
    using Xunit;
    public class PowersOfTwoTests {
        [Fact]
        public void NumsAreCorrect() {
            int num = default(N4096<int>).Num;

            Assert.Equal(expected: 4096, num);
        }

        [Fact]
        public unsafe void SizesAreCorrect() {
            int size = sizeof(N4096<byte>);

            Assert.Equal(expected: 4096, size);
        }
    }
}
