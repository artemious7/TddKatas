namespace CalcStats;

public class CalcStatsTests
{
    [Fact]
    public void GivenEmptyArray_ThenThrowsException()
    {
        Assert.Throws<ArgumentException>(() => CalcStats.Calculate([]));
    }

    // this sequence is tricky if double is used, but it works well with decimal
    static int[] tricky = Enumerable.Repeat((int[])[5, 1], 50).SelectMany(r => r).ToArray();

    public static readonly object[][] inputs =
    [
        [new int[] { 0 }, (0, 0, 1, 0m)],
        [new int[] { 1, 2 }, (1, 2, 2, 1.5m)],
        [new int[] { 2, 1, 3 }, (1, 3, 3, 2m)],
        [new int[] { 6, 9, 15, -2, 92, 11 }, (-2, 92, 6, 21.833333333333333333333333333m)],
        [new int[] { int.MaxValue / 2, int.MaxValue / 2 + 2 }, (int.MaxValue / 2, int.MaxValue / 2 + 2, 2, (decimal)(int.MaxValue / 2 + 1))],
        [tricky, (1, 5, tricky.Length, 3m)],
    ];

    [Theory]
    [MemberData(nameof(inputs))]
    public void Test(int[] input, (int, int, int, decimal) expected)
    {
        Assert.Equal(expected, CalcStats.Calculate(input));
    }
}