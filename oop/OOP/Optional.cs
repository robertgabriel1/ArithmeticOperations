﻿namespace OOP
{
    public class Optional : IPattern
    {
        private readonly IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);
            return new Match(true, match.RemainingText());
        }
    }
}
