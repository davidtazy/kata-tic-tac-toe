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
        public void at_start_game_is_on_going()
        {
            var game = new TestableGameBuilder().Build();

            Assert.AreEqual(GameResult.OnGoing, game.result);
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

        [Test]
        public void can_detect_player_has_won()
        {

            List<int[]> winning_pos = new List<int[]>();
            winning_pos.Add(new int[] { 1, 2, 3 });
            winning_pos.Add(new int[] { 4, 5, 6 });
            winning_pos.Add(new int[] { 7, 8, 9 });
            winning_pos.Add(new int[] { 1, 4, 7 });
            winning_pos.Add(new int[] { 2, 5, 8 });
            winning_pos.Add(new int[] { 3, 6, 9 });
            winning_pos.Add(new int[] { 1, 5, 9 });
            winning_pos.Add(new int[] { 3, 5, 7 });

            foreach (var pos in winning_pos)
            {
                var game = new TestableGameBuilder()
                                .Set_X_positions(pos)
                                .Build();

                game.UpdateResult();

                Assert.AreEqual(GameResult.PlayerX_won, game.result);
            }

            foreach (var pos in winning_pos)
            {
                var game = new TestableGameBuilder()
                                .Set_O_positions(pos)
                                .Build();
                game.UpdateResult();
                Assert.AreEqual(GameResult.PlayerO_won, game.result);
            }
        }

        [Test]
        public void can_detect_when_draw()
        {
            var game = new TestableGameBuilder()
                                    .Set_O_positions(new int[] { 2, 3, 4, 5, 9 })
                                    .Set_X_positions(new int[] { 1, 6, 7, 8 })
                                    .Build();


            game.UpdateResult();
            Assert.AreEqual(GameResult.Draw, game.result);
        }






    }
}