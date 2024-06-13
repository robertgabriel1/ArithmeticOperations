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
            if (prefix == null)
            {
                return text == null;
            }

            if (prefix.Length > text.Length - index)
            {
                return false;
            }

            return string.Compare(text, index, prefix, 0, prefix.Length) == 0;
        }
    }
}
