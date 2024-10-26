namespace Friday13th;

internal class Friday13th
{
    internal DayOfWeek GetMostFrequentDayOfWeek(DateOnly startDate, DateOnly endDate)
    {
        var the13Th = new DateOnly(startDate.Year, startDate.Month, 13);
        return the13Th.DayOfWeek;
    }
}
