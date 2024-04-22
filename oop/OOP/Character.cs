namespace OOP
{
    public class Character : IPattern
    {
        private readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || pattern != text[0])
                return new Match(false, text);

            return new Match(true, text[1..]);
        }
    }
}
