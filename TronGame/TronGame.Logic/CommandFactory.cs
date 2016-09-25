using TronGame.Logic.Exceptions;
using TronGame.Logic.Interfaces;
using TronGame.Logic.Moves;

namespace TronGame.Logic
{
    public static class CommandFactory
    {
        public static ICommand Get(string id, Player player)
        {
            switch (id.ToUpper())
            {
                case "U":
                    return new Up(player);
                case "D":
                    return new Down(player);
                case "L":
                    return new Left(player);
                case "R":
                    return new Right(player);
            }
            throw new CommandNotImplementedException("The command is not implemented");
        }
    }
}
