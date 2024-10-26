using FluentAssertions;
namespace Tennis;

public class TennisTests
{
    [Fact]
    public void WhenGameStarts_ThenLove_Love()
    {
        var sut = new Tennis();

        sut.StartGame();

        sut.ScoreDescription.Should().Be("love-love");
    }

    [Fact]
    public void WhenServerScores_Then15_Love()
    {
        var sut = new Tennis();
        sut.StartGame();

        sut.ServerScores();

        sut.ScoreDescription.Should().Be("15-love");
    }

    [Fact]
    public void WhenOpponentScores_ThenLove_15()
    {
        var sut = new Tennis();
        sut.StartGame();

        sut.OpponentScores();

        sut.ScoreDescription.Should().Be("love-15");
    }
}