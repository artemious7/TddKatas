namespace Tennis;

internal class Tennis
{
    private GameScore Score = new GameScore();
    public string ScoreDescription => Score.ToString();

    internal void StartGame()
    {

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
        return Points == 0 ? "love" : "";
    }
}