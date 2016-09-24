using System.Collections.Generic;

namespace TronGame.Logic
{
    public class Space : IEqualityComparer<Space>
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Space(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public bool Equals(Space x, Space y)
        {
            return x.XPos == y.XPos && y.XPos == x.YPos;
        }

        public int GetHashCode(Space space)
        {
            return XPos.GetHashCode() ^ YPos.GetHashCode();
        }
    }
}