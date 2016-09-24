using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronGame.Logic
{
    public class CommandsFileParser : ICommandsFileParser
    {
        private readonly string _fileName;
        private string _fileContent;

        public CommandsFileParser(string fileName)
        {
            this._fileName = fileName;
            this._fileContent = File.ReadAllText(fileName);
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            List<string> split = _fileContent.Split('|').ToList();
            var playerContent = split[0];
            this._fileContent = split[1];
            List<string> playersContent = playerContent.Split(';').ToList();
            foreach (var player in playersContent)
            {
                var playerFields = player.Split(',');
                players.Add(new Player {Color = Color.FromName(playerFields[1]), Name = playerFields[0]});
            }
            return players;
        }

        public IList<ICommand> GetCommands()
        {
            List<Player> players = GetPlayers();
            List<string> playerMoves = _fileContent.Split(',').ToList();
            List<ICommand> list = new List<ICommand>();
            foreach (var command in playerMoves)
            {
                var content = command.Split(':');
                Player player = players.FirstOrDefault(n => n.Name == content[0]);
                if (player != null) list.Add(CommandFactory.Get(content[1], player));
            }
            return list;
        }
    }
}
