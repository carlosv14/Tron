using System;

namespace TronGame.Logic.Exceptions
{
    public class CommandNotImplementedException : Exception
    {
        public CommandNotImplementedException(string message) : base(message)
        {
        }

    }
}