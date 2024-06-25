namespace OOP
{
    public class Character : IPattern
    {
        private readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(StringView text)
        {
            return !text.IsEmpty() && pattern == text.Peek()
            ? new Match(true, text.Advance())
            : new Match(false, text);
        }
    }
}
