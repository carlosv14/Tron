using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class CommandsFileParser : ICommandsFileParser
    {
        private string _fileContent;

        public CommandsFileParser(string fileName)
        {
            _fileContent = File.ReadAllText(fileName);
        }

        public List<Player> GetPlayers()
        {
            List<string> split = _fileContent.Split('|').ToList();
            var playerContent = split[0];
            _fileContent = split[1];
            var playersContent = playerContent.Split(';').ToList();
            return playersContent.Select(player => player.Split(','))
                .Select(playerFields => new Player {Color = Color.FromName(playerFields[1]), Name = playerFields[0]})
                .ToList();
            }

        public IList<ICommand> GetCommands(List<Player> players )
        {

            List<string> playerMoves = _fileContent.Split(',').ToList();
            
            return (playerMoves.Select(command => command.Split(':'))
                .Select(content => new {content, player = players.FirstOrDefault(n => n.Name == content[0])})
                .Where(t => t.player != null)
                .Select(t => CommandFactory.Get(t.content[1], t.player))).ToList();
        }

        public ICommandsFile Parse()
        {
            var players = GetPlayers();
            return new CommandsFile {Commands = GetCommands(players), Players = players};
        }
    }
}
