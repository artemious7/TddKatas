namespace CombinedNumberTddKata;

static class CombinedNumber
{
    public static string Answer(int[] input) => string.Join("", AnswerAsListOfInt([.. input]));

    internal static List<int> AnswerAsListOfInt(List<int> input)
    {
        for (int i = 0; i < input.Count; i++)
        {
            int item = input[i];
            int best = FindBestPosition(item, i);
            input.RemoveAt(i);
            input.Insert(best, item);
        }
        return input;

        int FindBestPosition(int item, int endIndex) => input
            .Take(endIndex)
            .Select((item, index) => (item, index: (int?)index))
            .FirstOrDefault(x => NumberHelpers.IsXYGreaterThanOrEqualToYX(item, x.item))
            .index ?? endIndex;
    }
}
