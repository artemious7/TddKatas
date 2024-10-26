namespace Friday13th;

public class Friday13thTests
{
    public static readonly object[][] Data = 
    [
        [new DateOnly(2024, 10, 1), DayOfWeek.Sunday],
    ];

    [Theory]
    [MemberData(nameof(Data))]
    public void TestMonths(DateOnly startDate, DayOfWeek expected)
    {
        var sut = new Friday13th();

        DayOfWeek mostFrequentDayOfWeek = sut.GetMostFrequentDayOfWeek(startDate, new DateOnly(2024, 10, 31));

        Assert.Equal(expected, mostFrequentDayOfWeek);
    }
}