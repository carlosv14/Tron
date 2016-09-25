using System.Collections.Generic;

namespace TronGame.Logic.Interfaces
{
    public interface ICommandsFile
    {
        List<Player> Players { get; set; }
        IList<ICommand> Commands { get; set; }
        string GetContent(string fileName);
    }
}