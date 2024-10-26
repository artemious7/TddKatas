namespace Friday13th;

internal class Friday13th
{
    internal DayOfWeek GetMostFrequentDayOfWeek(DateOnly startDate, DateOnly endDate)
    {
        Dictionary<DayOfWeek, int> counts = [];
        var startThe13Th = new DateOnly(startDate.Year, startDate.Month, 13);
        var endThe13Th = new DateOnly(endDate.Year, endDate.Month, 13);
        counts[startThe13Th.DayOfWeek] = 1;
        counts[endThe13Th.DayOfWeek] = 1;
        return counts.MaxBy(r => r.Value).Key;
    }
}
