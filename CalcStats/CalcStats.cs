namespace CalcStatsTddKata;

internal static class CalcStats
{
    public static (int minimum, int maximum, int count, decimal average) Calculate(int[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException("should not be empty", nameof(input));
        }

        var result = (min: int.MaxValue, max: int.MinValue, count: input.Length, average: 0m);
        decimal average = 0;
        foreach (var item in input)
        {
            if (item < result.min)
            {
                result.min = item;
            }
            if (item > result.max)
            {
                result.max = item;
            }
            average += (decimal)item / input.Length;
        }
        result.average = average;
        return result;
    }
}
