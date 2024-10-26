using FluentAssertions;
namespace Tennis;

public class TennisTests
{
    [Fact]
    public void WhenGameStarts_ThenLoveLove()
    {
        var sut = new Tennis();

        sut.StartGame();

        sut.ScoreDescription.Should().Be("love-love");
    }
}