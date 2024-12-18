using FluentAssertions;
namespace Tennis;

public class TennisTests
{
    private readonly Tennis sut = new();

    public TennisTests()
    {
        sut.Restart();
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
    public void GivenServerWon_WhenServerScores_ThenGameRestartedAndScoreIs15_Love()
    {
        ServerScores(4);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("15-love");
    }

    [Fact]
    public void GivenServerWon_WhenOpponentScores_ThenGameRestartedAndScoreIsLove_15()
    {
        ServerScores(4);

        OpponentScores(1);

        sut.ScoreDescription.Should().Be("love-15");
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void GivenServerScoresOneLessThanOpponent_WhenServerScores_ThenDeuce(int serverPoints)
    {
        GivenServerScoresOneLessThanOpponent(serverPoints);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("deuce");
    }

    private void GivenServerScoresOneLessThanOpponent(int serverPoints)
    {
        ServerScores(serverPoints);
        OpponentScores(serverPoints + 1);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void GivenDeuce_WhenServerScores_ThenServerHasAdvantage(int serverPoints)
    {
        GivenDeuce(serverPoints);

        ServerScores(1);

        sut.ScoreDescription.Should().Be("A-40");
    }

    private void GivenDeuce(int initialServerPoints)
    {
        ServerScores(initialServerPoints);
        OpponentScores(initialServerPoints + 1);
        ServerScores(1);
    }

    [Fact]
    public void WhenOpponentScores_ThenLove_15()
    {
        sut.OpponentWinsPoint();

        sut.ScoreDescription.Should().Be("love-15");
    }

    private void ServerScores(int points)
    {
        for (int i = 0; i < points; i++)
        {
            sut.ServerWinsPoint();
        }
    }

    private void OpponentScores(int points)
    {
        for (int i = 0; i < points; i++)
        {
            sut.OpponentWinsPoint();
        }
    }
}