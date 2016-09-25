using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class CommandsFile : ICommandsFile
    {
        public List<Player> Players { get; set; }
        public Dictionary<Player, ICommand> Commands { get; set; }
        public string GetContent(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
