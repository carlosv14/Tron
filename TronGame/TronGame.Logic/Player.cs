using System.Drawing;

namespace TronGame.Logic
{
    public class Player
    {
        public string Name { get; set; }
        public Color Color{ get; set; }
        public Space Position { get; set; }

        public Player Move(int vertical, int horizontal)
        {
            Position.XPos += horizontal;
            Position.YPos += vertical;
            return this;
        }
    }
}