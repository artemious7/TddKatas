using static CombinedNumberTddKata.CombinedNumber;

namespace CombinedNumberTddKata;

public class CombinedNumberTests
{
    [Theory]
    [InlineData((int[])[0], "0")]
    [InlineData((int[])[500], "500")]
    [InlineData((int[])[1, 0], "10")]
    [InlineData((int[])[0, 1], "10")]
    [InlineData((int[])[2, 10], "210")]
    [InlineData((int[])[2, 10, 3], "3210")]
    [InlineData((int[])[50, 2, 1, 9], "95021")]
    [InlineData((int[])[5, 50, 56], "56550")]
    [InlineData((int[])[420, 42, 423], "42423420")]
    [InlineData((int[])[420, 42, 423, 9], "942423420")]
    [InlineData((int[])[420, 42, 423, 4], "442423420")]
    [InlineData((int[])[420, 42, 423, 1], "424234201")]
    [InlineData((int[])[3, 33, 330], "333330")]
    public void TestStrings(int[] input, string expected)
    {
        Assert.Equal(expected, Answer([.. input]));
    }

    [Theory]
    [InlineData((int[])[0], (int[])[0])]
    [InlineData((int[])[500], (int[])[500])]
    [InlineData((int[])[1, 0], (int[])[1, 0])]
    [InlineData((int[])[0, 1], (int[])[1, 0])]
    [InlineData((int[])[2, 10], (int[])[2, 10])]
    [InlineData((int[])[2, 3, 10], (int[])[3, 2, 10])]
    [InlineData((int[])[50, 2, 1, 9], (int[])[9, 50, 2, 1])]
    [InlineData((int[])[5, 50], (int[])[5, 50])]
    [InlineData((int[])[50, 5], (int[])[5, 50])]
    [InlineData((int[])[5, 50, 56], (int[])[56, 5, 50])]
    [InlineData((int[])[420, 42, 423], (int[])[42, 423, 420])]
    [InlineData((int[])[420, 42, 423, 9], (int[])[9, 42, 423, 420])]
    [InlineData((int[])[420, 42, 423, 4], (int[])[4, 42, 423, 420])]
    [InlineData((int[])[420, 42, 423, 1], (int[])[42, 423, 420, 1])]
    [InlineData((int[])[3, 33, 330], (int[])[33, 3, 330])]
    public void TestArrays(int[] input, int[] expected)
    {
        Assert.Equal(expected, AnswerAsListOfInt([.. input]));
    }
}
