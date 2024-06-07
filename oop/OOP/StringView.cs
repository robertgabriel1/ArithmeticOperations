namespace OOP
{
    public class StringView
    {
        private readonly string text;
        private readonly int index;

        public StringView(string text, int index)
        {
            this.text = text;
            this.index = index;
        }

        public char Peek()
        {
            return text[index];
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(text) || index >= text.Length;
        }

        public StringView Advance(int count = 1)
        {
            return new StringView(text, index + count);
        }

        public bool StartsWith(string prefix)
        {
            if (prefix.Length > text.Length)
            {
                return false;
            }

            return string.Compare(text, 0, prefix, 0, prefix.Length) == 0;
        }
    }
}
