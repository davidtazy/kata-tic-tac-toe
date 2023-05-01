namespace TicTacToe.Cli
{
    public enum Player
    {
        O = 0,
        X = 10
    }

    public enum GameResult
    {
        PlayerX_won,
        PlayerO_won,
        Draw,
        OnGoing
    }

    internal struct State
    {
        public Player player { get; set; }
        public GameResult result { get; set; }

        public int[] board { get; set; }
    }
}