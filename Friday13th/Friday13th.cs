namespace Friday13th;

internal class Friday13th
{
    internal DayOfWeek GetMostFrequentDayOfWeek(DateOnly startDate, DateOnly endDate)
    {
        Dictionary<DayOfWeek, int> counts = [];
        for (DayOfWeek day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
        {
            counts[day] = 0;
        }
        for (var currentDate = new DateOnly(startDate.Year, startDate.Month, 13); currentDate < endDate; currentDate = currentDate.AddMonths(1))
        {
            counts[currentDate.DayOfWeek]++;
        }
        return counts.MaxBy(r => r.Value).Key;
    }
}
