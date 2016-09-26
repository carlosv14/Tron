using System.IO;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class CommandsFile : ICommandsFile
    {
        public string GetContent(string fileName)
        {
            var fileContent = File.ReadAllText(fileName);
            return fileContent;
        }
    }
}
