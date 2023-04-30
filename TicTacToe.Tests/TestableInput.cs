namespace TicTacToe.Tests
{

    internal class TestableInput : TicTacToe.Cli.Input
    {
        Queue<string> inputs = new Queue<string>();
        public List<string> messages = new List<string>();

        public string? Read()
        {
            return inputs.Dequeue();
        }

        public void Write(string message)
        {
            messages.Add(message);
        }

        internal void SetPlayersInput(string[] inputs_)
        {
            inputs = new Queue<string>(inputs_);

        }

        internal string LastMessage()
        {
            int count = messages.Count;
            if (count == 0) return "";

            return messages[count - 1];




        }
    }
}