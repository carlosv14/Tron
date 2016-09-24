using System;
using System.Runtime.Serialization;

namespace TronGame.Logic
{
    public class CommandNotImplementedException : Exception
    {
        public CommandNotImplementedException(string message) : base(message)
        {
        }

    }
}