namespace Friday13th;

public class Friday13thTests
{
    public static readonly object[][] Data =
    [
        [new DateOnly(2024, 10, 1), new object[] { DayOfWeek.Sunday }],
        [new DateOnly(2024, 09, 1), new object[] { DayOfWeek.Sunday, DayOfWeek.Friday }],
        [new DateOnly(2024, 03, 1), new object[] { DayOfWeek.Saturday }],
    ];

    [Theory]
    [MemberData(nameof(Data))]
    public void TestMonths(DateOnly startDate, DayOfWeek[] acceptible)
    {
        var sut = new Friday13th();

        DayOfWeek mostFrequentDayOfWeek = sut.GetMostFrequentDayOfWeek(startDate, new DateOnly(2024, 10, 31));

        Assert.Contains(mostFrequentDayOfWeek, acceptible);
    }
}