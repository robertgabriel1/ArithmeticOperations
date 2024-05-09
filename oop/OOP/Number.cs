namespace OOP
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var signs = new Any("-+");
            var exponentSign = new Any("Ee");
            var dot = new Character('.');
            var negativeChar = new Character('-');
            var onlyZeroAsInteger = new Sequence(new Optional(negativeChar), new Character('0')); 
            var multiNumberInteger = new Sequence(new Optional(negativeChar), new Range('1', '9'), new Many(digit));
            var checkValidExponent = new Sequence(exponentSign, new Optional(signs), digits);
            var integerPart = new Choice(onlyZeroAsInteger, multiNumberInteger);
            var fractionalPart = new Choice(new Sequence(dot, digits));
            var exponentPart = new Choice(checkValidExponent);
            pattern = new Sequence(integerPart, new Optional(fractionalPart), new Optional(exponentPart));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
