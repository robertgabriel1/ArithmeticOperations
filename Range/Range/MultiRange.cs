namespace RangeTask
{
    public class MultiRange
    {
        private Range[] ranges;
        public MultiRange()
        {
            ranges = new Range[0];
        }

        public void AddRange(Range range)
        {
            Range[] temp = new Range[ranges.Length + 1];
            for (int i = 0; i < ranges.Length; i++)
            {
                temp[i] = ranges[i];
            }

            ranges = temp;
            ranges[^1] = range;
        }
        
        public void RemoveRange(Range range)
        {
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == range)
                {
                    for (int j = i + 1; j < ranges.Length; j++)
                    {
                        ranges[j - 1] = ranges[j];
                    }
                }
            }

            Array.Resize(ref ranges, ranges.Length - 1);
        }

        public bool Query(Range range)
        {
            foreach (Range r in ranges)
            {
                if (r.Covers(range))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetLength()
        {
            return ranges.Length;
        }
    }
}
