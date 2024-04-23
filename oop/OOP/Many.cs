namespace OOP
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);
            do
            {
                text = match.RemainingText();
                match = pattern.Match(text);
            } while (match.Success());

            return new Match(true, text);
        }
    }
}
