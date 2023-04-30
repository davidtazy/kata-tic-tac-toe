using TicTacToe.Cli;


namespace TicTacToe.Tests
{
    public class TicTacToeShould
    {
        [Test]
        public void Do_something_when_this_happens()
        {
            var input = new TestableInput();
            var game = new Game(input);

            Assert.IsFalse(true);
        }
    }
}