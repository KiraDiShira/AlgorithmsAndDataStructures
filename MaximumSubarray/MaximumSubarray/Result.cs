namespace MaximumSubarray
{
    internal class Result
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Sum { get; set; }

        public override string ToString()
        {
            return $"{nameof(Low)}: {Low}, {nameof(High)}: {High}, {nameof(Sum)}: {Sum}";
        }
    }
}