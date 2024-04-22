namespace OOPTests
{
    public class RangeFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenValueIsInRange()
        {
            OOP.Range range = new('a', 'f');
            Assert.True(range.Match("abc").Success());
            Assert.True(range.Match("fab").Success());
            Assert.True(range.Match("bcd").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenValueIsNotInRange()
        {
            OOP.Range range = new('a', 'f');
            Assert.False(range.Match("1ab").Success());
        }
    }
}