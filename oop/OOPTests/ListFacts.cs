using OOP;

namespace OOPTests
{
    public class ListFacts
    {

        [Fact]
        public void Match_Should_ReturnEmptyString_WhenEveryThingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("1,2,3", 0)).Success());
            Assert.Equal(new StringView("1,2,3", 5), (a.Match(new StringView("1,2,3", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_RemoveWhatMatches_WhenAlmostEverythingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("1,2,3,", 0)).Success());
            Assert.Equal(new StringView("1,2,3,", 6), (a.Match(new StringView("1,2,3,", 0)).RemainingText()));

            Assert.True(a.Match(new StringView("1a", 0)).Success());
            Assert.Equal(new StringView("1a", 2), (a.Match(new StringView("1a", 0)).RemainingText()));

            Assert.True(a.Match(new StringView("1,2,3!", 0)).Success());
            Assert.Equal(new StringView("1,2,3!", 6), (a.Match(new StringView("1,2,3", 0)).RemainingText()));
        }


        [Fact]
        public void Match_Should_ReturnSameString_WhenNothingMatches()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("abc", 0)).Success());
            Assert.Equal(new StringView("abc", 0), a.Match(new StringView("abc", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameString_WhenStartsWithSeparator()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView(",1,2,3", 0)).Success());
            Assert.Equal(new StringView(",1,2,3", 0), a.Match(new StringView(",1,2,3", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameString_EmptyOrNull()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("", 0)).Success());
            Assert.Equal(new StringView("", 0), a.Match(new StringView("", 0)).RemainingText());

            Assert.True(a.Match(new StringView(null, 0)).Success());
            Assert.Equal(new StringView(null, 0), a.Match(new StringView(null, 0)).RemainingText());
        }


        [Fact]
        public void Match_Should_ReturnExpected_WhenCombiningSeveralClasses()
        {
            var digits = new OneOrMore(new OOP.Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match(new StringView("1; 22  ;\n 333 \t; 22", 0)).Success());
            Assert.Equal(new StringView("", 0), list.Match(new StringView("1; 22  ;\n 333 \t; 22", 0)).RemainingText());

            Assert.True(list.Match(new StringView("1 \n;", 0)).Success());
            Assert.Equal(new StringView(" \n;", 0), list.Match(new StringView("1 \n;", 0)).RemainingText());

            Assert.True(list.Match(new StringView("abc", 0)).Success());
            Assert.Equal(new StringView("abc", 0), list.Match(new StringView("abc", 0)).RemainingText());
        }
    }
}
