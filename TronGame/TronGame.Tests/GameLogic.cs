using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TronGame.Console;
using TronGame.Logic;
using TronGame.Logic.Interfaces;
using TronGame.Logic.Model;

namespace TronGame.Tests
{
    [Binding]
    public class GameLogic
    {
        private Mock<ICommandsFile> _fileMock;
        private Mock<ICommandsFileParser> _fileParserMock;
        private ICommandsFileParser _fileParser;
        private CommandsFileModel _file;
        private Game _game;
        private string _fileName;

        private CommandsFileModel ParseToModel(Table table)
        {
            var tableFileModel = new CommandsFileModel
            {
                Players = new List<Player>(),
                Commands = new List<ICommand>()
            };
            var players = new List<Player>();
            foreach (var row in table.Rows)
            {
                var playerInfo = row[0].Split(' ');
                players.Add(new Player { Color = Color.FromName(playerInfo[1]), Name = playerInfo[0] });
                tableFileModel.Players.Add(players.Last());
                var commandInfo = row[1].Split(':');
                tableFileModel.Commands.Add(CommandFactory.Get(commandInfo[1], players.FirstOrDefault(p => p.Name == commandInfo[0])));
            }
            return tableFileModel;
        }

        [Given(@"I have a file named '(.*)'")]
        public void GivenIHaveAFileNamed(string p0)
        {
            _fileMock = new Mock<ICommandsFile>();
            _fileName = p0;
        }


        [Given(@"The content of the file is '(.*)'")]
        public void GivenTheContentOfTheFileIs(string p0)
        {
            _fileMock.Setup(l => l.GetContent(It.IsAny<string>())).Returns(p0);
            _fileParser = new CommandsFileParser(_fileName, _fileMock.Object);
        }
        
        [When(@"I parse the file")]
        public void WhenIParseTheFile()
        {
          _file = _fileParser.Parse();
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            var tableFileModel = ParseToModel(table);
            Assert.AreEqual(tableFileModel,_file);
        }

        [Given(@"The commands are given in the file are")]
        public void GivenTheCommandsAreGivenInTheFileAre(Table table)
        {
            _fileParserMock = new Mock<ICommandsFileParser>();
            var tableFileModel = ParseToModel(table);
            _fileParserMock.Setup(s => s.Parse()).Returns(tableFileModel);

        }

        [When(@"I execute the game")]
        public void WhenIExecuteTheGame()
        {
            _game = new Game(_fileParserMock.Object);
            _game.Play();
        }

        [Then(@"the loser should be '(.*)'")]
        public void ThenTheResultLoserShouldBe(string p0)
        {
            Assert.AreEqual(p0.IsNullOrEmpty() ? null : p0, _game._loser);
        }
    }
}
