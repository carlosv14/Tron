using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronGame.Logic
{
    public class CommandsFile
    {
        public List<Player> Players { get; set; }
        public Dictionary<Player, ICommand> Commands { get; set; } 
    }
}
