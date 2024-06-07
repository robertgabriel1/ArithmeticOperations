namespace OOP
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(StringView text)
        {
            foreach (var pattern in patterns)
            {
                var matchPattern = pattern.Match(text);
                if (matchPattern.Success())
                {
                    return matchPattern;
                }
            }

            return new Match(false, text);
        }

        public void Add(IPattern newPattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = newPattern;
        }
    }
}
