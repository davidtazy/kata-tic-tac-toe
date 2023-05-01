using TicTacToe.Cli;


namespace TicTacToe.Tests
{
    internal class TestableGame : TicTacToe.Cli.Game
    {
        TestableInput testableInput;

        public TestableGame(TestableInput input_) : base(input_)
        {
            testableInput = input_;
        }

        internal void SetPlayersInput(string[] inputs)
        {
            testableInput.SetPlayersInput(inputs);
        }

        internal void Set_O_positions(int[] positions)
        {
            foreach (int pos in positions)
            {
                base.board[pos] = (int)Player.O;
            }
        }

        internal void Set_X_positions(int[] positions)
        {
            foreach (int pos in positions)
            {
                base.board[pos] = (int)Player.X;
            }
        }




    }
}