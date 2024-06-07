namespace OOP
{
    public class Match : IMatch
    {
        private readonly bool success;
        private readonly StringView remainingText;
        public Match(bool succes, StringView remainingText)
        {
            this.success = succes;
            this.remainingText = remainingText;
        }

        public StringView RemainingText()
        {
            return remainingText;
        }

        public bool Success()
        {
            return success;
        }
    }
}
