namespace TypeNum.Tests {
    using System;
    using Xunit;
    using ArrayOfTwoInts = FixedArray<Twice<N1<int>, int>, int>;

    public class FixedArrayTests {
        [Fact]
        public void ElementCount() {
            int actualCount = ArrayOfTwoInts.ElementCount;

            Assert.Equal(expected: 2, actual: actualCount);
        }

        [Fact]
        public void Indexing() {
            var array = new ArrayOfTwoInts {
                [0] = 1,
                [1] = 2
            };

            Assert.Equal(expected: 1, array[0]);
            Assert.Equal(expected: 2, array[1]);
        }

        [Fact]
        public void OutOfBoundsIndexThrows() {
            var array = new ArrayOfTwoInts();
            Assert.Throws<IndexOutOfRangeException>(() => array[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => array[2]);
        }

        [Fact]
        public void Contains() {
            var array = new ArrayOfTwoInts {
                [0] = 1,
                [1] = 2,
            };

            Assert.Contains(2, array);
            Assert.DoesNotContain(3, array);
        }
    }
}
