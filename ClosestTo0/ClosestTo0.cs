namespace ClosestTo0;

internal static class ClosestTo0
{
    public static int Approach1(int[] input)
    {
        return input.OrderDescending().MinBy(Math.Abs);
    }

    public static int Approach2(int[] input)
    {
        int closest = int.MaxValue;
        int closestAbsolute = int.MaxValue;
        foreach (var item in input)
        {
            int itemAbsolute = Math.Abs(item);
            int difference = closestAbsolute - itemAbsolute;
            if (ThisIsCloserToZero() || ItsATie() && item > 0)
            {
                (closest, closestAbsolute) = (item, itemAbsolute);
            }

            bool ThisIsCloserToZero() => difference > 0;
            bool ItsATie() => difference == 0;
        }
        return closest;
    }

    private static readonly IComparer<int> comparer = Comparer<int>.Create(new Comparison<int>((a, b) => Math.Abs(a).CompareTo(Math.Abs(b))));
    public static int Approach3(int[] input)
    {
        return input.OrderDescending().Min(comparer);
    }
}
