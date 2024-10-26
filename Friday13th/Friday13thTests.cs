using System.Collections.Immutable;
using Xunit.Abstractions;

namespace Friday13th;

public class Friday13thTests(ITestOutputHelper testOutputHelper)
{
    public static readonly object[][] MostFrequentDayOfWeekData =
    [
        [new DateOnly(2024, 10, 1), new object[] { DayOfWeek.Sunday }],
        [new DateOnly(2024, 09, 1), new object[] { DayOfWeek.Sunday, DayOfWeek.Friday }],
        [new DateOnly(2024, 03, 1), new object[] { DayOfWeek.Saturday }],
        [new DateOnly(1973, 01, 1), new object[] { DayOfWeek.Tuesday }],
    ];

    [Theory]
    [MemberData(nameof(MostFrequentDayOfWeekData))]
    public void TestMonths(DateOnly startDate, DayOfWeek[] acceptible)
    {
        var sut = new Friday13th();

        DayOfWeek mostFrequentDayOfWeek = sut.GetMostFrequentDayOfWeek(startDate, new DateOnly(2024, 10, 31));

        Assert.Contains(mostFrequentDayOfWeek, acceptible);
    }
    static readonly ImmutableDictionary<DayOfWeek, int> emptyCounts = Enumerable.Range(0, 7)
        .Select(days => DayOfWeek.Sunday + days)
        .ToDictionary(dayOfWeek => dayOfWeek, _ => 0)
        .ToImmutableDictionary();

    public static readonly object[][] CountsData =
    [
        [new DateOnly(2024, 10, 1), emptyCounts.SetItem(DayOfWeek.Sunday, 1)],
        [new DateOnly(2024, 09, 1), emptyCounts.SetItem(DayOfWeek.Sunday, 1).SetItem(DayOfWeek.Friday, 1)],
        [new DateOnly(2024, 03, 1), emptyCounts
            .SetItem(DayOfWeek.Sunday, 1)
            .SetItem(DayOfWeek.Friday, 1)
            .SetItem(DayOfWeek.Tuesday, 1)
            .SetItem(DayOfWeek.Saturday, 2)
            .SetItem(DayOfWeek.Thursday, 1)
            .SetItem(DayOfWeek.Monday, 1)
            .SetItem(DayOfWeek.Wednesday, 1)
            ],
    ];

    [Theory]
    [MemberData(nameof(CountsData))]
    public void TestCounts(DateOnly startDate, ImmutableDictionary<DayOfWeek, int> expectedCounts)
    {
        var sut = new Friday13th();
        Dictionary<DayOfWeek, int> counts = sut.GetCounts(startDate, new DateOnly(2024, 10, 31));
        TestCountsEquality(expectedCounts, counts);
    }

    [Fact]
    public void OutputCountsFrom1973()
    {
        DateOnly startDate = new DateOnly(1973, 1, 1);
        var sut = new Friday13th();
        Dictionary<DayOfWeek, int> counts = sut.GetCounts(startDate, new DateOnly(2024, 10, 31));

        testOutputHelper.WriteLine(string.Join(Environment.NewLine, counts.Select(r => $"{r.Key}: {r.Value}")));
        Assert.True(true);
    }

    [Theory]
    [InlineData(2015, 2025, new int[] { 2015 })]
    [InlineData(2015, 2026, new int[] { 2015, 2026 })]
    public void GetYearsWithMostFridaysTests(int startYear, int endYear, int[] expectedYears)
    {
        var sut = new Friday13th();
        var years = sut.GetYearsWithMostFridays(startYear, endYear);
        Assert.Equal(expectedYears, years);
    }

    [Fact]
    public void AssertForDictionaryUsesDeepEquality()
    {
        ImmutableDictionary<DayOfWeek, int> sunday = emptyCounts.SetItem(DayOfWeek.Sunday, 1);
        TestCountsEquality(sunday, sunday.ToDictionary());
    }

    private static void TestCountsEquality(ImmutableDictionary<DayOfWeek, int> dictionary1, Dictionary<DayOfWeek, int> dictionary2)
    {
        Assert.Equal(dictionary1, dictionary2);
    }
}