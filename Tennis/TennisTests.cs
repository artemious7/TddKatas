using FluentAssertions;
namespace Tennis;

public class TennisTests
{
    private readonly Tennis sut = new();

    public TennisTests()
    {
        sut.StartGame();
    }

    [Theory]
    [InlineData(0, "love-love")]
    [InlineData(1, "15-love")]
    [InlineData(2, "30-love")]
    [InlineData(3, "40-love")]
    [InlineData(4, "Server wins!")]
    public void ServerScoresTests(int times, string expectedScore)
    {
        ServerScores(times);

        sut.ScoreDescription.Should().Be(expectedScore);
    }

    [Fact]
    public void WhenOpponentScores_ThenLove_15()
    {
        sut.OpponentScores();

        sut.ScoreDescription.Should().Be("love-15");
    }

    private void ServerScores(int points)
    {
        for (int i = 0; i < points; i++)
        {
            sut.ServerScores();
        }
    }
}