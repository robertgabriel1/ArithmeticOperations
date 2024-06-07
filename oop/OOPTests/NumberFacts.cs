using OOP;

namespace OOPTests
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("0", 0)).Success());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView("a", 0)).Success());
            Assert.False(number.Match(new StringView("A", 0)).Success());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("7", 0)).Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("70", 0)).Success());
        }

        [Fact]
        public void IsNotNull()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView(null, 0)).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView(string.Empty, 0)).Success());
        }

        [Fact]
        public void CanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("-26", 0)).Success());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("-0", 0)).Success());
        }

        [Fact]
        public void CanBeFractional()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("12.34", 0)).Success());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("0.00000001", 0)).Success());
            Assert.True(number.Match(new StringView("10.00000001", 0)).Success());
        }

        [Fact]
        public void DoesStartWithADot()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView(".12", 0)).Success());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("12e3", 0)).Success());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("12E3", 0)).Success());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("12e+3", 0)).Success());
        }


        [Fact]
        public void TheExponentCanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("61e-9", 0)).Success());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            Number number = new Number();
            Assert.True(number.Match(new StringView("12.34E3", 0)).Success());
        }

        [Fact]
        public void SignOnlyIsNotValid()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView("+", 0)).Success());
            Assert.False(number.Match(new StringView("-", 0)).Success());
        }

        [Fact]
        public void DoesStartWithExponent()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView("e52", 0)).Success());
            Assert.False(number.Match(new StringView("E34", 0)).Success());
        }

        [Fact]
        public void DoesStartWithPositiveSign()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView("+13", 0)).Success());
            Assert.False(number.Match(new StringView("+34e5", 0)).Success());
        }

        [Fact]
        public void CanNotHaveMultipleLeadingNegativeSigns()
        {
            Number number = new Number();
            Assert.False(number.Match(new StringView("--46", 0)).Success());
        }
    }
}
