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

    internal int[] GetYearsWithMostFridays(int startYear, int endYearInclusive)
    {
        var yearsByMostFridays = new Dictionary<int /* number of Fridays */, List<int> /* years */>();
        for (int year = startYear; year <= endYearInclusive; year++)
        {
            var date = new DateOnly(year, 1, 1);
            var counts = GetCounts(date, date.AddYears(1));
            int numberOfFridays = counts[DayOfWeek.Friday];
            if (!yearsByMostFridays.TryGetValue(numberOfFridays, out var years))
            {
                years = yearsByMostFridays[numberOfFridays] = [];
            }
            years.Add(year);
        }
        return [.. yearsByMostFridays.MaxBy(r => r.Key).Value];
    }
}
