namespace BowlingGameScore.Approach3;

public class BowlingGameTests
{
    [Fact]
    public void GivenAllStrikesAnd2BonusThrows10PinsBoth_ThenScoreIs300()
    {
        object[] input = [.. (int[][]) [
            [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0], [10, 0] ], 10, 10 ];
        BowlingGame sut = new(input);
        int score = sut.Calculate();
        score.Should().Be(300);
    }

    [Fact]
    public void GivenNormalThrowsWith1BonusThrow10Pins_ThenScoreIs148()
    {
        object[] input = [.. (int[][]) [
            [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10],[ 10, 0], [6, 4], [7, 3] ], 10 ];
        BowlingGame sut = new(input);
        int score = sut.Calculate();
        score.Should().Be(148);
    }

    [Fact]
    public void GivenNormalThrowsWithoutBonusThrows_ThenScoreIs137()
    {
        object[] input = [.. (int[][]) [
            [5, 3], [8, 2], [10, 0], [10, 0], [1, 0], [9, 1], [0, 10],[ 10, 0], [6, 4], [7, 2] ] ];
        BowlingGame sut = new(input);
        int score = sut.Calculate();
        score.Should().Be(137);
    }

    [Theory]
    [InlineData([(object[])[(int[])[2, 3]], 2 + 3, "normal frame"])]
    [InlineData([(object[])[(int[])[2, 3], (int[])[1, 2]], 2 + 3 + 1 + 2, "normal frame + normal frame"])]
    [InlineData([(object[])[(int[])[1, 9], (int[])[2, 3]], 1 + 9 + 2 + 2 + 3, "spare frame + normal frame"])]
    [InlineData([(object[])[(int[])[10, 0], (int[])[2, 3]], 10 + 2 + 3 + 2 + 3, "strike frame + normal frame"])]
    [InlineData([(object[])[(int[])[10, 0], (int[])[10, 0], (int[])[2, 3]], 10 + 10 + 2 + 10 + 2 + 3 + 2 + 3, "2 strike frames + normal frame"])]
    [InlineData([(object[])[(int[])[10, 0], 1, 2], 10 + 1 + 2, "strike frame + 2 bonus throws"])]
    [InlineData([(object[])[(int[])[9, 1], 2], 9 + 1 + 2, "spare frame + bonus throw"])]
    public void Tests(object[] input, int expectedScore, string description)
    {
        BowlingGame sut = new(input);
        int score = sut.Calculate();
        score.Should().Be(expectedScore, because: description);
    }
}
