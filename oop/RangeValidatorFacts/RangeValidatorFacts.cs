namespace RangeValidatorFacts
{
    public class RangeValidatorFacts
    {
        [Fact]
        public void Match_ShouldReturnExpectedResult()
        {
            RangeValidator.Range range = new('a', 'f');
            Assert.True(range.Match("abc"));
            Assert.True(range.Match("fab"));
            Assert.True(range.Match("bcd"));
            Assert.False(range.Match("1ab"));
        }
    }
}