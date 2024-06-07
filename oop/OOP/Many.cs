﻿namespace OOP
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(StringView text)
        {
            var match = pattern.Match(text);
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }

            return new Match(true, match.RemainingText());
        }
    }
}
