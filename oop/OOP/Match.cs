namespace OOP
{
    public class Match : IMatch
    {
        private readonly bool success;
        private readonly string remainingText;
        public Match(bool succes, string remainingText)
        {
            this.success = succes;
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Success()
        {
            return success;
        }
    }
}
