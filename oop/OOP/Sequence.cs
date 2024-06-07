namespace OOP
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }
        public IMatch Match(StringView text)
        {
            IMatch matchPattern = new Match(true, text);

            foreach (var pattern in patterns)
            {
                matchPattern = pattern.Match(matchPattern.RemainingText());
                if (!matchPattern.Success())
                {
                    return new Match(false, text);
                }
            }

            return matchPattern;
        }
    }
}
