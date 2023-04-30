namespace TicTacToe.Cli
{
    internal class ConsoleInput : Input
    {
        public string? Read()
        {
            return System.Console.ReadLine();
        }
    }
}