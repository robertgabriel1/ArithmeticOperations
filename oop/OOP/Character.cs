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
            return !string.IsNullOrEmpty(text) && pattern == text[0] 
            ? new Match(true, text[1..])
            : new Match(false, text);
        }
    }
}
