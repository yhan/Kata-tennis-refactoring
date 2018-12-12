namespace Tennis
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}