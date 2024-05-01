using OOP;

namespace OOPTests
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            Number number = new Number();
            Assert.True(number.Match("0").Success());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Number number = new Number();
            Assert.False(number.Match("a").Success());
            Assert.False(number.Match("A").Success());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Number number = new Number();
            Assert.True(number.Match("7").Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Number number = new Number();
            Assert.True(number.Match("70").Success());
        }

        [Fact]
        public void IsNotNull()
        {
            Number number = new Number();
            Assert.False(number.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Number number = new Number();
            Assert.False(number.Match(string.Empty).Success());
        }

        [Fact]
        public void DoesNotStartWithZero()
        {
            Number number = new Number();
            Assert.False(number.Match("07").Success());
            Assert.False(number.Match("017").Success());
            Assert.False(number.Match("-017").Success());
        }

        [Fact]
        public void CanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match("-26").Success());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Number number = new Number();
            Assert.True(number.Match("-0").Success());
        }

        [Fact]
        public void CanBeFractional()
        {
            Number number = new Number();
            Assert.True(number.Match("12.34").Success());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Number number = new Number();
            Assert.True(number.Match("0.00000001").Success());
            Assert.True(number.Match("10.00000001").Success());
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            Number number = new Number();
            Assert.False(number.Match("12.").Success());
        }

        [Fact]
        public void DoesStartWithADot()
        {
            Number number = new Number();
            Assert.False(number.Match(".12").Success());
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            Number number = new Number();
            Assert.False(number.Match("12.34.56").Success());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            Number number = new Number();
            Assert.False(number.Match("12.3x").Success());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Number number = new Number();
            Assert.True(number.Match("12e3").Success());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Number number = new Number();
            Assert.True(number.Match("12E3").Success());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Number number = new Number();
            Assert.True(number.Match("12e+3").Success());
        }


        [Fact]
        public void TheExponentCanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match("61e-9").Success());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            Number number = new Number();
            Assert.True(number.Match("12.34E3").Success());
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            Number number = new Number();
            Assert.False(number.Match("22e3x3").Success());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            Number number = new Number();
            Assert.False(number.Match("22e323e33").Success());
            Assert.False(number.Match("22.3e323e33").Success());
            Assert.False(number.Match("22.3e-323e33").Success());
            Assert.False(number.Match("22.3E-323E33").Success());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete()
        {
            Number number = new Number();
            Assert.False(number.Match("22e").Success());
            Assert.False(number.Match("22E").Success());
            Assert.False(number.Match("22e+").Success());
            Assert.False(number.Match("23E-").Success());
        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            Number number = new Number();
            Assert.False(number.Match("22e3.3").Success());
        }

        [Fact]
        public void TheExponentIsFirstAfterDot()
        {
            Number number = new Number();
            Assert.False(number.Match("22.e33").Success());
        }

        [Fact]
        public void SignOnlyIsNotValid()
        {
            Number number = new Number();
            Assert.False(number.Match("+").Success());
            Assert.False(number.Match("-").Success());
        }

        [Fact]
        public void DoesNotContainInvalidSymbol()
        {
            Number number = new Number();
            Assert.False(number.Match("123#456").Success());
            Assert.False(number.Match("12$34").Success());
            Assert.False(number.Match("1%23").Success());
        }

        [Fact]
        public void SignCannotBeBeforeExponent()
        {
            Number number = new Number();
            Assert.False(number.Match("12+e3").Success());
            Assert.False(number.Match("12-e3").Success());
        }

        [Fact]
        public void DoesNotHaveTwoOrMoreSigns()
        {
            Number number = new Number();
            Assert.False(number.Match("22.3e++3").Success());
            Assert.False(number.Match("14.3e--323e33").Success());
            Assert.False(number.Match("26.3e-3+5-7").Success());
        }

        [Fact]
        public void DoesStartWithExponent()
        {
            Number number = new Number();
            Assert.False(number.Match("e52").Success());
            Assert.False(number.Match("E34").Success());
        }

        [Fact]
        public void DoesStartWithPositiveSign()
        {
            Number number = new Number();
            Assert.False(number.Match("+13").Success());
            Assert.False(number.Match("+34e5").Success());
        }

        [Fact]
        public void CanNotHaveMultipleLeadingNegativeSigns()
        {
            Number number = new Number();
            Assert.False(number.Match("--46").Success());
        }

        [Fact]
        public void ExponentialSignShouldAppearAfterExponent()
        {
            Number number = new Number();
            Assert.False(number.Match("123ea-67").Success());
            Assert.False(number.Match("123e2-67").Success());
        }
    }
}
