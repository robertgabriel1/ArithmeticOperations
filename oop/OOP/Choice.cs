namespace OOP
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
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
    }
}
