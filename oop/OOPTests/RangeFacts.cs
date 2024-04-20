namespace OOPTests
{
    public class RangeFacts
    {
        [Fact]
        public void Match_ShouldReturnExpectedResult()
        {
            OOP.Range range = new('a', 'f');
            Assert.True(range.Match("abc"));
            Assert.True(range.Match("fab"));
            Assert.True(range.Match("bcd"));
            Assert.False(range.Match("1ab"));
        }
    }
}