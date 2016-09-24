using System;

namespace TronGame.Logic.Exceptions
{
    [Serializable]
    internal class CommandNotImplementedException : Exception
    {
        public CommandNotImplementedException(string message) : base(message)
        {
        }

    }
}