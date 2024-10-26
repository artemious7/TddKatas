namespace Friday13th;

internal class Friday13th
{
    private const int DayOfMonth = 13;

    internal Dictionary<DayOfWeek, int> GetCounts(DateOnly startDate, DateOnly endDate)
    {
        Dictionary<DayOfWeek, int> counts = Enumerable.Range(0, 7)
            .Select(days => DayOfWeek.Sunday + days)
            .ToDictionary(dayOfWeek => dayOfWeek, _ => 0);

        for (var currentDate = new DateOnly(startDate.Year, startDate.Month, DayOfMonth); currentDate < endDate; currentDate = currentDate.AddMonths(1))
        {
            counts[currentDate.DayOfWeek]++;
        }
        return counts;
    }

    internal DayOfWeek GetMostFrequentDayOfWeek(DateOnly startDate, DateOnly endDate)
    {
        var counts = GetCounts(startDate, endDate);
        return counts.MaxBy(r => r.Value).Key;
    }
}
