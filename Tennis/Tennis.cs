

namespace Tennis;

internal class Tennis
{
    private GameScore Score = ZeroScore();
    public string ScoreDescription => Score.ToString();

    internal void StartGame()
    {
        Score = ZeroScore();
    }

    private static GameScore ZeroScore() => new(new(0, "Server"), new(0, "Opponent"));

    internal void ServerScores()
    {
        Score.Server.Points++;
    }

    internal void OpponentScores()
    {
        Score.Opponent.Points++;
    }

    private record GameScore(Player Server, Player Opponent)
    {
        private const int MinimumPointsToWin = 4;

        public override string ToString() =>
            Server.Points == Opponent.Points && Server.Points >= 3 ?
                "deuce" :
                LeadingPlayer.Points >= MinimumPointsToWin ?
                    $"{LeadingPlayer.Role} wins!" :
                    $"{Server}-{Opponent}";

        private Player LeadingPlayer => Server.Points >= Opponent.Points ? Server : Opponent;
    }

    private record Player(int Points, string Role)
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