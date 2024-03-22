using Xunit;
using static Json.JsonNumber;

namespace Json.Facts
{
    public class JsonNumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            Assert.True(IsJsonNumber("0"));
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Assert.False(IsJsonNumber("a"));
            Assert.False(IsJsonNumber("A"));
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Assert.True(IsJsonNumber("7"));
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Assert.True(IsJsonNumber("70"));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(IsJsonNumber(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(IsJsonNumber(string.Empty));
        }

        [Fact]
        public void DoesNotStartWithZero()
        {
            Assert.False(IsJsonNumber("07"));
            Assert.False(IsJsonNumber("017"));
            Assert.False(IsJsonNumber("-017"));
        }

        [Fact]
        public void CanBeNegative()
        {
            Assert.True(IsJsonNumber("-26"));
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Assert.True(IsJsonNumber("-0"));
        }

        [Fact]
        public void CanBeFractional()
        {
            Assert.True(IsJsonNumber("12.34"));
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Assert.True(IsJsonNumber("0.00000001"));
            Assert.True(IsJsonNumber("10.00000001"));
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            Assert.False(IsJsonNumber("12."));
        }

        [Fact]
        public void DoesStartWithADot()
        {
            Assert.False(IsJsonNumber(".12"));
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            Assert.False(IsJsonNumber("12.34.56"));
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            Assert.False(IsJsonNumber("12.3x"));
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Assert.True(IsJsonNumber("12e3"));
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Assert.True(IsJsonNumber("12E3"));
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Assert.True(IsJsonNumber("12e+3"));
        }


        [Fact]
        public void TheExponentCanBeNegative()
        {
            Assert.True(IsJsonNumber("61e-9"));
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            Assert.True(IsJsonNumber("12.34E3"));
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            Assert.False(IsJsonNumber("22e3x3"));
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            Assert.False(IsJsonNumber("22e323e33"));
            Assert.False(IsJsonNumber("22.3e323e33"));
            Assert.False(IsJsonNumber("22.3e-323e33"));
            Assert.False(IsJsonNumber("22.3E-323E33"));
        }

        [Fact]
        public void TheExponentIsAlwaysComplete()
        {
            Assert.False(IsJsonNumber("22e"));
            Assert.False(IsJsonNumber("22E"));
            Assert.False(IsJsonNumber("22e+"));
            Assert.False(IsJsonNumber("23E-"));
        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            Assert.False(IsJsonNumber("22e3.3"));
        }

        [Fact]
        public void TheExponentIsFirstAfterDot()
        {
            Assert.False(IsJsonNumber("22.e33"));
        }

        [Fact]
        public void SignOnlyIsNotValid()
        {
            Assert.False(IsJsonNumber("+"));
            Assert.False(IsJsonNumber("-"));
        }

        [Fact]
        public void DoesNotContainInvalidSymbol()
        {
            Assert.False(IsJsonNumber("123#456"));
            Assert.False(IsJsonNumber("12$34"));
            Assert.False(IsJsonNumber("1%23"));
        }

        [Fact]
        public void SignCannotBeBeforeExponent()
        {
            Assert.False(IsJsonNumber("12+e3"));
            Assert.False(IsJsonNumber("12-e3"));
        }

        [Fact]
        public void DoesNotHaveTwoOrMoreSigns()
        {
            Assert.False(IsJsonNumber("22.3e++3"));
            Assert.False(IsJsonNumber("14.3e--323e33"));
            Assert.False(IsJsonNumber("26.3e-3+5-7"));
        }

        [Fact]
        public void DoesStartWithExponent()
        {
            Assert.False(IsJsonNumber("e52"));
            Assert.False(IsJsonNumber("E34"));
        }

        [Fact]
        public void DoesStartWithPositiveSign()
        {
            Assert.False(IsJsonNumber("+13"));
            Assert.False(IsJsonNumber("+34e5"));
        }

        [Fact]
        public void CanNotHaveMultipleLeadingNegativeSigns()
        {
            Assert.False(IsJsonNumber("--46"));
        }

        [Fact]
        public void ExponentialSignShouldAppearAfterExponent()
        {
            Assert.False(IsJsonNumber("123ea-67"));
            Assert.False(IsJsonNumber("123e2-67"));
        }
    }
}
