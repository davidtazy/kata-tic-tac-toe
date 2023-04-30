
namespace TicTacToe.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            Input input = new ConsoleInput();
            var game = new Game(input);

            System.Console.WriteLine("TicTacToe!");

            while (!game.is_over)
            {
                game.PrintBoard();
                game.Play();
            }

            System.Console.WriteLine($"Finished !!! \n Result: {game.Result()}");
            System.Console.ReadLine();
        }
    }


}
