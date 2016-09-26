using System.Collections.Generic;

namespace TronGame.Logic
{
    public class SpaceEqualityComparer : IEqualityComparer<Space>
    {
        public bool Equals(Space x, Space y)
        {
            return x.XPos == y.XPos && y.YPos == x.YPos;
        }

        public int GetHashCode(Space space)
        {
            return space.XPos.GetHashCode() ^ space.YPos.GetHashCode();
        }
    }
}