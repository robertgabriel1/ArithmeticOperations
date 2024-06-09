using OOP;

namespace OOPTests
{
    public class StringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted("abc"), 0)).Success());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView("abc\"", 0)).Success());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView("\"abc", 0)).Success());
        }

        [Fact]
        public void IsNotNull()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(null, 0)).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(string.Empty, 0)).Success());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(string.Empty), 0)).Success());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(Quoted("a\nb\rc"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"\""a\"" b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \\ b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \/ b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \b b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \f b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \n b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \r b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \t b"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"a \u26Be b"), 0)).Success());
        }

        [Fact]
        public void CanContainAnyMultipleEscapeSequences()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"\\\u1212\n\t\r\\\b"), 0)).Success());
            Assert.True(text.Match(new StringView(Quoted(@"\u1212\\\n\t\r\\\b"), 0)).Success());
            Assert.True(text.Match(new StringView(Quoted(@"\\u1212\\\n\t\r\\\b"), 0)).Success());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(Quoted(@"a\x"), 0)).Success());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(Quoted(@"a\"), 0)).Success());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(Quoted(@"a\u"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted(@"a\u123"), 0)).Success());
        }

        [Fact]
        public void DoesNotContainHexadecimalControlCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(new StringView(Quoted("\u000A"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted("\u000D"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted("\u0009"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted("\u0008"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted("\u000C"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted("\u005C"), 0)).Success());
        }

        [Fact]
        public void CanContainOnlyUnderscore()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted("_"), 0)).Success());
        }

        [Fact]
        public void CanContainLeadingAndTrailingWhitespaces()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(" abc "), 0)).Success());
        }

        [Fact]
        public void CanContainSpecialCharacters()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted("!@#$%^&*()"), 0)).Success());
        }

        [Fact]
        public void CanContainEscapedBackslashes()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(new StringView(Quoted(@"\\abc"), 0)).Success());
            Assert.False(text.Match(new StringView(Quoted(@"\\a\xbc"), 0)).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
