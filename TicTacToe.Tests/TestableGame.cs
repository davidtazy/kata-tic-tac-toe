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

        public void SetBoard(int[] b)
        {
            base.board = board;
        }

        internal void SetPlayersInput(string[] inputs)
        {
            testableInput.SetPlayersInput(inputs);
        }

        internal void Set_O_positions(int[] positions)
        {
            foreach (int pos in positions)
            {
                base.board[pos - 1] = (int)Player.O;
            }
        }

        internal void Set_X_positions(int[] positions)
        {
            foreach (int pos in positions)
            {
                base.board[pos - 1] = (int)Player.X;
            }
        }




    }
}