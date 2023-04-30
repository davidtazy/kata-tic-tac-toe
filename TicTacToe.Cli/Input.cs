namespace TicTacToe.Cli
{
    public interface Input
    {
        public string? Read();
        void Write(string message);
    }
}
