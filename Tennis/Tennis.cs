

namespace Tennis;

internal class Tennis
{
    private GameScore Score = new GameScore();
    public string ScoreDescription => Score.ToString();

    internal void StartGame()
    {

    }

    internal void ServerScores()
    {
        Score = Score with { ServerPoints = Score.ServerPoints with { Points = Score.ServerPoints.Points + 1 } };
    }

    internal void OpponentScores()
    {
        Score = Score with { OpponentPoints = Score.OpponentPoints with { Points = Score.OpponentPoints.Points + 1 } };
    }
}

internal record struct GameScore(PlayerPoints ServerPoints, PlayerPoints OpponentPoints)
{
    public override string ToString() => $"{ServerPoints}-{OpponentPoints}";
}

internal record struct PlayerPoints(int Points)
{
    public override string ToString()
    {
        return Points switch
        {
            0 => "love",
            1 => "15",
            _ => ""
        };
    }
}