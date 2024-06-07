using OOP;

namespace OOPTests
{
    public class SequenceFacts
    {
        [Theory]
        [InlineData("abcd", true)]
        [InlineData("ax", false)]
        [InlineData("def", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Match_Should_ReturnExpected(string? value, bool expectedResult)
        {
            var ab = new Sequence(
            new Character('a'),
            new Character('b')
            );

            Assert.Equal(expectedResult, ab.Match(new StringView(value, 0)).Success());

            var abc = new Sequence(
            ab,
            new Character('c')
            );

            Assert.Equal(expectedResult, abc.Match(new StringView(value, 0)).Success());
        }

        [Theory]
        [InlineData("u1234", true)]
        [InlineData("uabcdef", true)]
        [InlineData("uB005 ab", true)]
        [InlineData("abc", false)]
        [InlineData(null, false)]
        public void Match_Should_ReturnExpected_ForHex(string? value, bool expectedResult)
        {
            var hex = new Choice(
            new OOP.Range('0', '9'),
            new OOP.Range('a', 'f'),
            new OOP.Range('A', 'F')
            );

            var hexSeq = new Sequence(
            new Character('u'),
            new Sequence(
            hex,
            hex,
            hex,
            hex
            )
            );

            Assert.Equal(expectedResult, hexSeq.Match(new StringView(value, 0)).Success());
        }
    }
}