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

    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    public void GivenServerScoresOneLessThanOpponent_WhenServerScores_ThenDeuce(int serverPoints, int opponentPoints)
    {
        ServerScores(serverPoints);
        OpponentScores(opponentPoints);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("deuce");
    }

    [Theory]
    [InlineData(2, 3)]
    public void GivenDeuce_WhenServerScores_ThenServerHasAdvantage(int serverPoints, int opponentPoints)
    {
        ServerScores(serverPoints);
        OpponentScores(opponentPoints);
        ServerScores(1);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("A-40");
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