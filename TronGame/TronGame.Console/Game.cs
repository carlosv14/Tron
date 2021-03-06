﻿using System;
using System.Collections.Generic;
using System.Linq;
using TronGame.Logic;
using TronGame.Logic.Interfaces;

namespace TronGame.Console
{
    public class Game
    {
        private readonly List<Player> _players;
        private readonly IList<ICommand> _commands;
        private readonly Dictionary<Space, string> _board;
        private readonly int _height;
        public string Loser { get; private set; }
        private readonly int _width;

        public Game(ICommandsFileParser commandsFileParser)
        {

            var commandsFileParser1 = commandsFileParser;
            var playersAndCommands = commandsFileParser1.Parse();
            _players = playersAndCommands.Players;
            _commands = playersAndCommands.Commands;
            _height = 10;
            _width = 10;
            _board = GenerateBoard();
            SetStartingPositions();
        }

        private Dictionary<Space, string> GenerateBoard()
        {
            return Enumerable.Range(0, _width)
                    .SelectMany(val => Enumerable.Range(0, _height).Select(inVal => new Tuple<int, int>(val, inVal)))
                    .Zip(Enumerable.Repeat("-", _width * _height).ToList(),
                        (space, character) => new Tuple<Space, string>(new Space(space.Item1,space.Item2), character))
                        .ToDictionary(t=>t.Item1,t=>t.Item2, new SpaceEqualityComparer()); 
        }


        private void SetStartingPositions()
        {
            _players[0].Position=new Space(0,0);
            _players[1].Position= new Space(9,9);
            _board[_players[0].Position]= _players[0].Color.Name.ToCharArray()[0].ToString();
            _board[_players[1].Position] = _players[1].Color.Name.ToCharArray()[0].ToString();
        }

        public void Play()
        {
            ActionRunner actionRunner = ActionRunner.Instance();
            while (_commands.Count > 0)
            {
                var player=actionRunner.PerformAction(_commands.First(), _width, _height);
                _commands.RemoveAt(0);
                if (_board[player.Position] == "-")
                    _board[player.Position] = player.Color.Name.ToCharArray()[0].ToString();
                else
                {
                    Loser = player.Name;
                    break;
                }
            }
            PrintBoard();
            PrintWinner();
            
        }

        private void PrintWinner()
        {
            if (Loser==null)
                System.Console.WriteLine("Tie!!!!");
            else
                System.Console.WriteLine(Loser+" Lost!!!");
        }

        private void PrintBoard()
        {
            var currentSpace= new Space(0,0);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    currentSpace.XPos = j;
                    currentSpace.YPos = i;
                    System.Console.Write(_board[currentSpace]+" ");
                }
                System.Console.Write("\r\n");
            }
        }

    }

}
