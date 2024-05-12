namespace OOP
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var signs = new Any("-+");
            var exponentSign = new Any("Ee");
            var dot = new Character('.');
            var negativeChar = new Character('-');
            var singleZero = new Character('0');
            var integerPart = new Sequence(new Optional(negativeChar), new Choice(singleZero, digits));
            var fractionalPart = new Optional(new Sequence(dot, digits));
            var exponentPart = new Optional(new Sequence(exponentSign, new Optional(signs), digits));
            pattern = new Sequence(integerPart, fractionalPart, exponentPart);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
