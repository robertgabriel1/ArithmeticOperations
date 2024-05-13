namespace OOP
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            pattern = new Character('.');
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
