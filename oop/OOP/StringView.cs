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
            return !IsEmpty() ? text[index] : '0';
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

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] != text[index + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
