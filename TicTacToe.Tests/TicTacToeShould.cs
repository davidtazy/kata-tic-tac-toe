using TicTacToe.Cli;


namespace TicTacToe.Tests
{


    struct TestableGameBuilder
    {
        public TestableInput input = new TestableInput();
        public TestableGame game;

        public TestableGameBuilder()
        {
            game = new TestableGame(input);
        }

        public TestableGameBuilder SetBoard(int[] board)
        {
            game.SetBoard(board);
            return this;
        }

        public Game Build()
        {
            return game;
        }

        internal TestableGameBuilder Set_O_positions(int[] positions)
        {
            game.Set_O_positions(positions);
            return this;
        }

        internal TestableGameBuilder Set_X_positions(int[] positions)
        {
            game.Set_X_positions(positions);
            return this;
        }

        internal TestableGameBuilder SetPlayersInput(string[] inputs)
        {
            game.SetPlayersInput(inputs);
            return this;
        }
    }

    public class TicTacToeShould
    {
        [Test]
        public void at_start_first_player_is_X()
        {
            var game = new TestableGameBuilder().Build();

            Assert.AreEqual(Player.X, game.player);
        }

        [Test]
        public void at_start_game_is_not_over()
        {
            var game = new TestableGameBuilder().Build();

            Assert.IsFalse(game.is_over);
        }

        [Test]
        public void at_start_board_is_clear()
        {
            var game = new TestableGameBuilder().Build();

            var clear_board = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(clear_board, game.board);
            Assert.AreEqual(clear_board, game.free_cell);
        }

        [Test]
        public void can_check_if_cell_is_free()
        {
            var game = new TestableGameBuilder()
                                    .Set_O_positions(new int[] { 1, 3, 4 })
                                    .Set_X_positions(new int[] { 2 })
                                    .Build();

            for (int pos = 1; pos <= 4; pos++)
            {
                Assert.False(game.is_free_cell(pos));
            }

            for (int pos = 5; pos <= 9; pos++)
            {
                Assert.True(game.is_free_cell(pos));
            }
        }

        [Test]
        public void prompt_choice_will_player_select_a_free_cell()
        {
            var game = new TestableGameBuilder()
                                    .Set_O_positions(new int[] { 1, 3, 4 })
                                    .Set_X_positions(new int[] { 2 })
                                    .SetPlayersInput(new string[] { "0", "1", "dfsd", "39", null, "6", "7" })
                                    .Build();

            Assert.AreEqual(6, game.PromptNextPlayedPosition());
        }

        [Test]
        public void PrintPrettyBoard()
        {
            var builder = new TestableGameBuilder()
                                    .Set_O_positions(new int[] { 1, 3, 4 })
                                    .Set_X_positions(new int[] { 2 });
            var game = builder.Build();
            var input = builder.input;

            game.PrintBoard();

            string board = @"+---+---+---+
| O | X | O |
+---+---+---+
| O | 5 | 6 |
+---+---+---+
| 7 | 8 | 9 |
+---+---+---+
";

            Assert.AreEqual(board, input.LastMessage());
        }

        [Test]
        public void after_played_pos_is_set_and_it_is_next_player_turn()
        {
            var game = new TestableGameBuilder()
                                    .SetPlayersInput(new string[] { "1", "2" })
                                    .Build();
            // X play
            game.Play();
            Assert.AreEqual((int)Player.X, game.board[0]);
            Assert.AreEqual(Player.O, game.player);

            // O play
            game.Play();
            Assert.AreEqual((int)Player.O, game.board[1]);
            Assert.AreEqual(Player.X, game.player);

        }






    }
}