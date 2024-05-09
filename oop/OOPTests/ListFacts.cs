using OOP;

namespace OOPTests
{
    public class ListFacts
    {

        [Fact]
        public void Match_Should_ReturnEmptyString_WhenEveryThingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void Match_Should_RemoveWhatMatches_WhenAlmostEverythingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match("1,2,3,").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());

            Assert.True(a.Match("").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());

            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());

            Assert.True(a.Match("1,2,3!").Success());
            Assert.Equal("!", a.Match("1,2,3!").RemainingText());

            Assert.Equal(",2", a.Match("1,,2").RemainingText());
        }


        [Fact]
        public void Match_Should_ReturnSameString_WhenNothingMatches()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameString_WhenStartsWithSeparator()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(",1,2,3").Success());
            Assert.Equal(",1,2,3", a.Match(",1,2,3").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameString_EmptyOrNull()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());

            Assert.True(a.Match(null).Success());
            Assert.Equal(null, a.Match(null).RemainingText());
        }


        [Fact]
        public void Match_Should_ReturnExpected_WhenCombiningSeveralClasses()
        {
            var digits = new OneOrMore(new OOP.Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());

            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());

            Assert.True(list.Match("abc").Success());
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }
    }
}
