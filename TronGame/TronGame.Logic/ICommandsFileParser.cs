using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronGame.Logic
{
    public interface ICommandsFileParser
    {
        List<Player> GetPlayers();
        Dictionary<Player, ICommand> GetCommands();
    }
}
