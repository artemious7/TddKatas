namespace Friday13th;

internal class Friday13th
{
    internal DayOfWeek GetMostFrequentDayOfWeek(DateOnly startDate, DateOnly endDate)
    {
        Dictionary<DayOfWeek, int> counts = [];
        for (var currentDate = new DateOnly(startDate.Year, startDate.Month, 13); currentDate < endDate; currentDate = currentDate.AddMonths(1))
        {
            counts[currentDate.DayOfWeek] = 1;
        }
        return counts.MaxBy(r => r.Value).Key;
    }
}
