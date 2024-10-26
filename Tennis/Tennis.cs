namespace Tennis;

internal class Tennis
{
    private GameScore Score = LoveLoveScore;

    public string ScoreDescription => Score.Description;

    internal void Restart() => Score = LoveLoveScore;

    private static GameScore LoveLoveScore => new(new(0, "Server"), new(0, "Opponent"));

    internal void ServerWinsPoint()
    {
        RestartIfHasAWinner();
        Score.Server.Points++;
    }

    internal void OpponentWinsPoint()
    {
        RestartIfHasAWinner();
        Score.Opponent.Points++;
    }

    private void RestartIfHasAWinner()
    {
        if (Score.HasAWinner)
        {
            Restart();
        }
    }

    private record GameScore(Player Server, Player Opponent)
    {
        public string Description =>
            HasAWinner ?
                $"{LeaderOrAnyPlayer.Role} wins!" :
                AtLeast3PointsScoredByEachAndPointsAreEqual() ?
                    "deuce" :
                    $"{Server.Score(LeaderOrAnyPlayer)}-{Opponent.Score(LeaderOrAnyPlayer)}";

        public bool HasAWinner => APlayerHasAtLeast4PointsAndAtLeast2More();

        private bool APlayerHasAtLeast4PointsAndAtLeast2More() =>
            LeaderOrAnyPlayer.Points >= MinimumPointsToWin && PointsDifference() >= 2;

        private const int MinimumPointsToWin = 4;

        private int PointsDifference() =>
            Math.Abs(Server.Points - Opponent.Points);

        private bool AtLeast3PointsScoredByEachAndPointsAreEqual() =>
            Server.Points == Opponent.Points && Server.Points >= 3;

        private Player LeaderOrAnyPlayer => Server.Points >= Opponent.Points ? Server : Opponent;
    }

    private record Player(int Points, string Role)
    {
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

        private const string Advantage = "A";
    }
}