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
        private string _fileContent;
        private List<Player> _players; 
        public CommandsFileParser(string fileName)
        {
            this._fileName = fileName;
            this._fileContent = File.ReadAllText(fileName);
        }

        public List<Player> GetPlayers()
        {
            this._players = new List<Player>();
            List<string> split = _fileContent.Split('|').ToList();
            var playerContent = split[0];
            this._fileContent = split[1];
            var playersContent = playerContent.Split(';').ToList();
            return playersContent.Select(player => player.Split(','))
                .Select(playerFields => new Player {Color = Color.FromName(playerFields[1]), Name = playerFields[0]})
                .ToList();
            }

        public IList<ICommand> GetCommands(List<Player> players )
        {

            Dictionary<Player, ICommand> commands = new Dictionary<Player, ICommand>();
            List<string> playerMoves = _fileContent.Split(',').ToList();
            
            return (playerMoves.Select(command => command.Split(':'))
                .Select(content => new {content, player = (Player) players.FirstOrDefault(n => n.Name == content[0])})
                .Where(@t => @t.player != null)
                .Select(@t => CommandFactory.Get(@t.content[1], @t.player))).ToList();
        }

        public ICommandsFile Parse()
        {
            var players = GetPlayers();
            return new CommandsFile {Commands = GetCommands(players), Players = players};
        }
    }
}
