namespace TronGame.Logic
{
    internal class Up : ICommand
    {
        public Player Player { get; set; }

        public Up(Player player)
        {
            Player = player;
        }

        public void Run()
        {
            Player.Move(0, -1);
        }
    }
}