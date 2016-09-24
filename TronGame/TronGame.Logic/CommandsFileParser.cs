using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class CommandsFileParser : ICommandsFileParser
    {
        private readonly string _fileName;
        private ICommandsFile _commandsFile;
        private string _fileContent;
        private List<Player> players; 
        public CommandsFileParser(string fileName, ICommandsFile commandsFile)
        {
            this._fileName = fileName;
            this._commandsFile = commandsFile;
            this._fileContent = this._commandsFile.GetContent(this._fileName);
        }

        private List<Player> GetPlayers()
        {
            this.players = new List<Player>();
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

        private Dictionary<Player, ICommand> GetCommands()
        {
            List<Player> players = GetPlayers();
            Dictionary<Player, ICommand> commands = new Dictionary<Player, ICommand>();
            List<string> playerMoves = _fileContent.Split(',').ToList();
            foreach (var command in playerMoves)
            {
                var content = command.Split(':');
                var player = players.FirstOrDefault(n => n.Name == content[0]);
                if (player != null)
                {
                    commands.Add(player, CommandFactory.Get(content[1]));
                }
            }
            return commands;
        }

        public ICommandsFile Parse()
        {
            return new CommandsFile {Commands = GetCommands(), Players = this.players};
        }
    }
}
