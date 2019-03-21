namespace TypeNum.Tests {
    using System;
    using Xunit;

    public class FixedArrayTests {
        [Fact]
        public void ElementCount() {
            int actualCount = FixedArray<Twice<N1<int>, int>, int>.ElementCount;

            Assert.Equal(expected: 2, actual: actualCount);
        }
    }
}
