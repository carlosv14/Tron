namespace TronGame.Logic
{
    internal class Down : ICommand
    {
        public Player Player { get; set; }

        public Down(Player player)
        {
            Player = player;
        }

        public void Run()
        {
            Player.Move(1, 0);
        }
    }
}