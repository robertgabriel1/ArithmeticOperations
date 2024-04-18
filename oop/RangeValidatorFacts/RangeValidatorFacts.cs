namespace RangeValidatorFacts
{
    public class RangeValidatorFacts
    {
        [Fact]
        public void Test1()
        {
            RangeValidator.Range range = new('a', 'f');
            Assert.True(range.Match("abc"));
            Assert.True(range.Match("fab"));
            Assert.True(range.Match("bcd"));
        }

        [Fact]
        public void Test2()
        {
            RangeValidator.Range range = new('a', 'f');
            Assert.False(range.Match("abg"));
            Assert.False(range.Match("1ab"));

        }
    }
}