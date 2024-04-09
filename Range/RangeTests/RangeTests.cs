using RangeTask;
namespace RangeTests
{
    public class RangeTests
    {
        [Fact]
        public void Covers_WhenRangeIsCovered_ReturnsTrue()
        {
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(2, 4);
            Assert.True(range1.IsCoveredBy(range2));
        }

        [Fact]
        public void Covers_WhenRangeIsNotCovered_ReturnsFalse()
        {
            RangeTask.Range range1 = new(1, 5);
            RangeTask.Range range2 = new(6, 10);
            Assert.False(range1.IsCoveredBy(range2));
        }
    }
}
