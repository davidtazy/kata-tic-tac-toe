
namespace TicTacToe.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            Input input = new ConsoleInput();
            var game = new Game(input);

            System.Console.WriteLine("TicTacToe!");

            while (game.result == GameResult.OnGoing)
            {
                game.PrintBoard();
                game.Play();
            }
            game.PrintBoard();
            System.Console.WriteLine($"Finished !!! \n Result: {game.ResultStr()}");
            System.Console.ReadLine();
        }
    }


}
