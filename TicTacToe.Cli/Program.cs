
namespace TicTacToe.Cli
{
    class Program
    {

        static void Main(string[] args)
        {
            Input input = new ConsoleInput();
            var game = new Game(input);

            System.Console.WriteLine("TicTacToe!");

            while (game.IsNotOver())
            {
                System.Console.WriteLine(game.PrintBoard());
                game.Play();
            }

            System.Console.WriteLine($"Finished !!! \n Result: {game.Result()}");
            System.Console.ReadLine();
        }
    }


}
