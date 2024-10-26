using FluentAssertions;
namespace Tennis;

public class TennisTests
{
    private readonly Tennis sut = new();

    public TennisTests()
    {
        sut.StartGame();
    }

    [Fact]
    public void WhenGameStarts_ThenLove_Love()
    {
        sut.ScoreDescription.Should().Be("love-love");
    }

    [Fact]
    public void WhenServerScores_Then15_Love()
    {
        sut.ServerScores();

        sut.ScoreDescription.Should().Be("15-love");
    }

    [Fact]
    public void WhenOpponentScores_ThenLove_15()
    {
        sut.OpponentScores();

        sut.ScoreDescription.Should().Be("love-15");
    }

    [Fact]
    public void WhenServerScoresTwice_Then30_Love()
    {
        sut.ServerScores();
        sut.ServerScores();

        sut.ScoreDescription.Should().Be("30-love");
    }

    [Fact]
    public void WhenServerScores3Times_Then40_Love()
    {
        sut.ServerScores();
        sut.ServerScores();
        sut.ServerScores();

        sut.ScoreDescription.Should().Be("40-love");
    }
}