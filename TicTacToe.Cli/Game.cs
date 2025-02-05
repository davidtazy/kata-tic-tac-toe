namespace TicTacToe.Cli
{



    public class Game
    {
        private Input input;

        public Player player
        {
            get { return state.player; }
        }
        public GameResult result
        {
            get { return state.result; }
        }

        public int[] board
        {
            get { return state.board; }
        }

        private State state = new State()
        {
            player = Player.X,

            result = GameResult.OnGoing,

            // insert 0 to align index and position 
            board = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };


        public Game(Input input_)
        {
            input = input_;
        }

        public void Play()
        {
            int pos = PromptNextPlayedPosition();
            state.board[pos] = (int)player;
            UpdateResult();
            NextPlayer();
        }

        private void NextPlayer()
        {
            if (player == Player.O)
                state.player = Player.X;
            else
                state.player = Player.O;
        }

        public void PrintBoard()
        {
            string line_sep = "+---+---+---+\n";
            string grid = line_sep;
            int index = 1;
            for (int line = 0; line < 3; line++)
            {
                grid += "|";
                for (int col = 0; col < 3; col++)
                {
                    grid += " ";
                    int val = board[index];
                    if (val == 0) grid += "O";
                    else if (val == 10) grid += "X";
                    else grid += val.ToString();
                    grid += " ";

                    index++;
                    grid += "|";
                }
                grid += "\n";
                grid += line_sep;
            }


            input.Write(grid);
        }

        public string ResultStr()
        {
            switch (result)
            {
                case GameResult.PlayerX_won: return "Player X won !!!";
                case GameResult.PlayerO_won: return "Player O won !!!";
                case GameResult.Draw: return "Draw !!!";
                case GameResult.OnGoing: return "On going game !!!";

            }
            throw new Exception(" Unhandled result");
        }

        public bool is_free_cell(int pos)
        {
            return state.board[pos] == pos;
        }

        public int PromptNextPlayedPosition()
        {

            while (true) // TODO  add a limit try number  a player loose
            {
                input.Write($"{player} select position to play: ");
                int ret = 0;
                string? str = input.Read();
                if (str != null)
                {
                    try
                    {
                        ret = Int32.Parse(str);
                    }
                    catch (Exception) { }
                }

                if (IsValidPosition(ret) && is_free_cell(ret))
                {
                    return ret;
                }
            }
        }

        private bool IsValidPosition(int position)
        {
            return position > 0 && position < 10;
        }

        public void UpdateResult()
        {

            // test if player won
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
                int sum = 0;
                foreach (int index in pos)
                {
                    sum += board[index];
                }

                if (sum == 0)
                {
                    state.result = GameResult.PlayerO_won;
                    return;
                }
                if (sum == 30)
                {
                    state.result = GameResult.PlayerX_won;
                    return;
                }
            }

            // test if free pos to play
            for (int i = 1; i <= 9; i++)
            {
                if (is_free_cell(i))
                {
                    return;
                }
            }

            state.result = GameResult.Draw;

        }


    }
}