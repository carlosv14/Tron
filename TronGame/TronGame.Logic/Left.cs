using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class Left : ICommand
    {
        public Player Player { get; set; }

        public Left(Player player)
        {
            Player = player;
        }

        public void Run()
        {
            Player.Move(0, -1);
        }
    }
}