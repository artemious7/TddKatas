


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
        if (Score.HasAWinner)
        {
            StartGame();
        }
        Score.Server.Points++;
    }


    internal void OpponentScores()
    {
        Score.Opponent.Points++;
    }

    private record GameScore(Player Server, Player Opponent)
    {
        public override string ToString() =>
            HasAWinner ?
                $"{Leader.Role} wins!" :
                AtLeast3PointsScoredByEachAndPointsAreEqual() ?
                    "deuce" :
                    $"{Server.Score(Leader)}-{Opponent.Score(Leader)}";

        public bool HasAWinner => APlayerHasAtLeast4PointsAndAtLeast2More();

        private bool APlayerHasAtLeast4PointsAndAtLeast2More() =>
            Leader.Points >= MinimumPointsToWin && PointsDifference() >= 2;

        private const int MinimumPointsToWin = 4;

        private int PointsDifference() =>
            Math.Abs(Server.Points - Opponent.Points);

        private bool AtLeast3PointsScoredByEachAndPointsAreEqual() =>
            Server.Points == Opponent.Points && Server.Points >= 3;

        private Player Leader => Server.Points >= Opponent.Points ? Server : Opponent;
    }

    private record Player(int Points, string Role)
    {
        private const string Advantage = "A";

        public int Points { get; set; } = Points;

        public string Score(Player leader) => Points switch
        {
            0 => "love",
            1 => "15",
            2 => "30",
            3 => "40",
            _ when this == leader => Advantage,
            _ => "40"
        };
    }
}