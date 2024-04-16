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
            bool merged = false;

            foreach (Range r in ranges)
            {
                MergeResult mergeResult = r.MergeInto(range);
                if (mergeResult.Result)
                {
                    if (!merged)
                    {
                        Array.Resize(ref ranges, ranges.Length + 1);
                        ranges[^1] = mergeResult.Merged;
                    }
                    RemoveRange(r);
                    merged = true;
                }
            }

            if (!merged)
            {
                Array.Resize(ref ranges, ranges.Length + 1);
                ranges[^1] = range;
            }
        }

        public void RemoveRange(Range range)
        {
            for (int i = 0; i < ranges.Length; i++)
            {
                (bool result, Range[] rangesLeft) = ranges[i].Split(range);
                if (result)
                {
                    ShiftElements(i);
                    foreach (Range rangeLeft in rangesLeft)
                    {
                        if (rangeLeft != null)
                        {
                            AddRange(rangeLeft);
                        }
                    }
                    break;
                }
            }
        }

        public void ShiftElements(int i)
        {
            for (int j = i + 1; j < ranges.Length; j++)
            {
                ranges[j - 1] = ranges[j];
            }
            Array.Resize(ref ranges, ranges.Length - 1);
        }

        public bool Query(Range range)
        {
            foreach (Range r in ranges)
            {
                if (r.IsOverlapping(range))
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