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

    [Theory]
    [InlineData(0, "love-love")]
    [InlineData(1, "love-15")]
    [InlineData(2, "love-30")]
    [InlineData(3, "love-40")]
    [InlineData(4, "Opponent wins!")]
    public void OpponentScoresTests(int times, string expectedScore)
    {
        OpponentScores(times);

        sut.ScoreDescription.Should().Be(expectedScore);
    }

    [Fact]
    public void GivenScoreIs30_40_WhenServerScores_ThenDeuce()
    {
        ServerScores(2);
        OpponentScores(3);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("deuce");
    }

    [Fact]
    public void GivenPointsAre3_4_WhenServerScores_ThenDeuce()
    {
        ServerScores(3);
        OpponentScores(4);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("deuce");
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

    private void OpponentScores(int points)
    {
        for (int i = 0; i < points; i++)
        {
            sut.OpponentScores();
        }
    }
}