using TronGame.Logic.Interfaces;

namespace TronGame.Logic.Moves
{
    public class Right : ICommand
    {
        public Player Player { get; set; }

        public Right(Player player)
        {
            Player = player;
        }

        public void Run()
        {
            Player.Move(0, 1);
        }
    }
}