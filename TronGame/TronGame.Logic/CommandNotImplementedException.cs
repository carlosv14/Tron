using System;
using System.Runtime.Serialization;

namespace TronGame.Logic
{
    [Serializable]
    internal class CommandNotImplementedException : Exception
    {
        public CommandNotImplementedException(string message) : base(message)
        {
        }

    }
}