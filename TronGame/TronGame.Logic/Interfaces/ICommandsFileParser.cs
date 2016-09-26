using System.Collections.Generic;
using TronGame.Logic.Model;

namespace TronGame.Logic.Interfaces
{
    public interface ICommandsFileParser
    {
        List<Player> GetPlayers();
        IList<ICommand> GetCommands(List<Player> players );
        CommandsFileModel Parse();
    }
}