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
            var playersContent = playerContent.Split(';').ToList();
            this._fileContent = filecontent;
            return playersContent.Select(player => player.Split(','))
                .Select(playerFields => new Player {Color = Color.FromName(playerFields[1]), Name = playerFields[0]})
                .ToList();
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
            var players = GetPlayers();
            var playerMoves = _fileContent.Split(',').ToList();
            return (playerMoves.Select(command => command.Split(':'))
                .Select(content => new {content, player = (Player) players.FirstOrDefault(n => n.Name == content[0])})
                .Where(@t => @t.player != null)
                .Select(@t => CommandFactory.Get(@t.content[1], @t.player))).ToList();
        }

        public ICommandsFile Parse()
        {
            return new CommandsFile {Commands = GetCommands(), Players = this.players};
        }
    }
}
