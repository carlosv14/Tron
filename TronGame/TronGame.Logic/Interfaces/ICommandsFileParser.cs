using System.Collections.Generic;

namespace TronGame.Logic.Interfaces
{
    public interface ICommandsFileParser
    {
        List<Player> GetPlayers();
        IList<ICommand> GetCommands(List<Player> players );
        ICommandsFile Parse();
    }
}