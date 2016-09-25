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
            var filecontent = this._fileContent;
            var split = _fileContent.Split('|').ToList();
            var playerContent = split[0];
            this._fileContent = split[1];
            var playersContent = playerContent.Split(';').ToList();
            this._fileContent = filecontent;
            return playersContent.Select(player => player.Split(','))
                .Select(playerFields => new Player {Color = Color.FromName(playerFields[1]), Name = playerFields[0]})
                .ToList();
        }

        public IList<ICommand> GetCommands()
        {
            var players = GetPlayers();
            var playerMoves = _fileContent.Split(',').ToList();
            return (playerMoves.Select(command => command.Split(':'))
                .Select(content => new {content, player = (Player) players.FirstOrDefault(n => n.Name == content[0])})
                .Where(@t => @t.player != null)
                .Select(@t => CommandFactory.Get(@t.content[1], @t.player))).ToList();
        }
    }
}