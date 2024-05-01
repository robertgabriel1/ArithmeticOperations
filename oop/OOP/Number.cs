namespace OOP
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var containsAnySign = new Any("-+");
            var containsExponent = new Any("Ee");
            var dot = new Character('.');
            var negativeChar = new Character('-');

            var checkValidExponent = new Sequence(containsExponent, new Optional(containsAnySign), digits);
            var integerPart = new Sequence(new Optional(negativeChar), new Choice(digits));
            var exponentPart = new Optional(checkValidExponent);
            var fractionalPart = new Optional(new Sequence(dot, digits));

            pattern = new Sequence(integerPart, fractionalPart, exponentPart);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
