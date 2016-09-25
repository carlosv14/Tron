using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TronGame.Logic;
using TronGame.Logic.Interfaces;

namespace TronGame.Tests
{
    [Binding]
    public class CorrectFileSteps
    {
        private Mock<ICommandsFile> _fileMock;
        private ICommandsFileParser _fileParser;
        private ICommandsFile _file;
        [Given(@"I have a file named '(.*)'")]
        public void GivenIHaveAFileNamed(string p0)
        {
            _fileMock = new Mock<ICommandsFile>();
        }


        [Given(@"The content of the file is '(.*)'")]
        public void GivenTheContentOfTheFileIs(string p0)
        {
            _fileMock.Setup(l => l.GetContent(It.IsAny<string>())).Returns(p0);
            _fileParser = new CommandsFileParser(p0, _fileMock.Object);
        }
        
        [When(@"I parse the file")]
        public void WhenIParseTheFile()
        {
          _file = _fileParser.Parse();
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            CommandsFile tableFile = new CommandsFile();
            tableFile.Players = new List<Player>();
            tableFile.Commands = new Dictionary<Player, ICommand>();
            List<Player> players = new List<Player>();
            foreach (var row in table.Rows)
            {
                var playerInfo = row[0].Split(' ');
                players.Add(new Player { Color = Color.FromName(playerInfo[1]), Name = playerInfo[0] });
                tableFile.Players.Add(players.Last());
                var commandInfo = row[1].Split(':');
                tableFile.Commands.Add(players.FirstOrDefault(p => p.Name == commandInfo[0]),CommandFactory.Get(commandInfo[1]));
            }
        }
    }
}
