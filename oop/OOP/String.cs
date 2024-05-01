namespace OOP
{
    public class StringClass : IPattern
    {
        private readonly IPattern pattern;

        public StringClass()
        {
            pattern = new Range('a','f');
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
