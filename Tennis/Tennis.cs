

namespace Tennis;

internal class Tennis
{
    private GameScore Score = new GameScore(new PlayerPoints(0), new PlayerPoints(0));
    public string ScoreDescription => Score.ToString();

    internal void StartGame()
    {
        Score = new GameScore(new PlayerPoints(0), new PlayerPoints(0));
    }

    internal void ServerScores()
    {
        Score.ServerPoints.Points++;
    }

    internal void OpponentScores()
    {
        Score.OpponentPoints.Points++;
    }

    private record GameScore(PlayerPoints ServerPoints, PlayerPoints OpponentPoints)
    {
        public override string ToString() => 
            ServerPoints.Points > 3 ? 
                "Server wins!" : 
                $"{ServerPoints}-{OpponentPoints}";
    }

    private record PlayerPoints(int Points)
    {
        public int Points { get; set; } = Points;

        public override string ToString() => Points switch
        {
            0 => "love",
            1 => "15",
            2 => "30",
            3 => "40",
            _ => ""
        };
    }
}