namespace TicTacToe.Tests
{

    internal class TestableInput : TicTacToe.Cli.Input
    {
        public string? Read()
        {
            throw new NotImplementedException();
        }
    }
}