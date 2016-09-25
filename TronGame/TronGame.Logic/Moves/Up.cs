using TronGame.Logic.Interfaces;

namespace TronGame.Logic.Moves
{
    public class Up : ICommand
    {
        public Player Player { get; set; }

        public Up(Player player)
        {
            Player = player;
        }

        public void Run()
        {
            Player.Move(-1,0);
        }
    }
}