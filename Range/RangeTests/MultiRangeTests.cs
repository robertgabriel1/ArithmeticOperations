using RangeTask;

namespace RangeTests
{
    public class MultiRangeTests
    {
        [Fact]
        public void AddRange_ShouldIncreaseLength()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(6, 7);
            RangeTask.Range range3 = new(12, 13);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.AddRange(range3);
            Assert.Equal(3, ranges.GetLength());
        }

        [Fact]
        public void AddRange_Test()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(0, 2);
            RangeTask.Range range2 = new(4, 6);
            RangeTask.Range range3 = new(1, 5);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.AddRange(range3);
            Assert.Equal(1, ranges.GetLength());
        }

        [Fact]
        public void AddRange_AddingExistingRange_ShouldMerge()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(2, 6);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            Assert.Equal(1, ranges.GetLength());
        }

        [Fact]
        public void RemoveRange_WithoutSplit_ShouldDecreaseLength()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(6, 7);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.RemoveRange(new RangeTask.Range(1, 5));
            Assert.Equal(1, ranges.GetLength());
        }

        [Fact]
        public void RemoveRange_WithSplit_ShouldIncreaseLength()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            ranges.AddRange(range1);
            ranges.RemoveRange(new RangeTask.Range(2, 3));
            Assert.Equal(2, ranges.GetLength());
        }

        [Fact]
        public void Query_ShouldReturnCorrectResult()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            ranges.AddRange(range1);
            Assert.True(ranges.Query(new RangeTask.Range(2, 3)));
            Assert.True(ranges.Query(new RangeTask.Range(3, 5)));
            Assert.False(ranges.Query(new RangeTask.Range(6, 18)));
        }
    }
}
