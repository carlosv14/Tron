﻿using System;
using System.Collections.Generic;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class CommandsFile : ICommandsFile
    {
        public List<Player> Players { get; set; }
        public IList<ICommand> Commands { get; set; }
        public string GetContent(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
