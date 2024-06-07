using OOP;

namespace OOPTests
{
    public class RangeFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenValueIsInRange()
        {
            OOP.Range range = new('a', 'f');
            Assert.True(range.Match(new StringView("abc", 0)).Success());
            Assert.True(range.Match(new StringView("fab", 0)).Success());
            Assert.True(range.Match(new StringView("bcd", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenValueIsNotInRange()
        {
            OOP.Range range = new('a', 'f');
            Assert.False(range.Match(new StringView("1ab", 0)).Success());
        }
    }
}