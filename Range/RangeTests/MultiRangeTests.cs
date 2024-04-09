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
            RangeTask.Range range2 = new(3, 7);
            RangeTask.Range range3 = new(2, 6);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.AddRange(range3);
            Assert.Equal(3, ranges.GetLength());
        }

        [Fact]
        public void RemoveRange_ShouldDecreaseLength()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(3, 7);
            RangeTask.Range range3 = new(2, 6);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.AddRange(range3);
            ranges.RemoveRange(range1);
            Assert.Equal(2, ranges.GetLength());
        }

        [Fact]
        public void Query_ShouldReturnCorrectResult()
        {
            MultiRange ranges = new();
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(3, 7);
            RangeTask.Range range3 = new(2, 6);
            ranges.AddRange(range1);
            ranges.AddRange(range2);
            ranges.AddRange(range3);
            Assert.True(ranges.Query(new RangeTask.Range(4, 7)));
            Assert.True(ranges.Query(new RangeTask.Range(3, 5)));
            Assert.False(ranges.Query(new RangeTask.Range(4, 18)));
        }
    }
}
