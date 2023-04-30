namespace TicTacToe.Cli
{

    public enum Player
    {
        O = 0,
        X = 10
    }

    public class Game
    {
        private Input input;

        public Player player { get; set; }
        public bool is_over { get; }

        public int[] board = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int[] free_cell = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Game(Input input_)
        {
            input = input_;
            player = Player.X;
            is_over = false;
        }



        public void Play()
        {
            int pos = PromptNextPlayedPosition();
            board[pos - 1] = (int)player;
            NextPlayer();
        }

        private void NextPlayer()
        {
            if (player == Player.O) player = Player.X;
            else player = Player.O;
        }

        public void PrintBoard()
        {
            string line_sep = "+---+---+---+\n";
            string grid = line_sep;
            int index = 0;
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

        public string Result()
        {
            throw new NotImplementedException();
        }

        public bool is_free_cell(int pos)
        {
            return board[pos - 1] == pos;
        }

        public int PromptNextPlayedPosition()
        {

            while (true) //  add a limit try number  a player loose
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


    }
}