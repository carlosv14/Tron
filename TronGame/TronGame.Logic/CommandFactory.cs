using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronGame.Logic.Exceptions;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public static class CommandFactory
    {
        public static ICommand Get(string id)
        {
            switch (id)
            {
                case "U":
                    return new Up();
                case "D":
                    return new Down();
                case "L":
                    return new Left();
                case "R":
                    return new Right();
            }
            throw new CommandNotImplementedException("The command is not implemented");
        }
    }
}
