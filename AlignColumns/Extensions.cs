public static class Extensions
{
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var value in values)
        {
            action(value);
        }
    }

    public static void ForEach(this Range range, Action<int> action)
    {
        range.Range().ForEach(action);
    }

    public static IEnumerable<int> Range(this Range range)
    {
        return Enumerable.Range(range.Start.Value, range.End.Value);
    }
}
