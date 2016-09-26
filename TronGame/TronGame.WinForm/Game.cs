using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronGame.Logic;
using TronGame.Logic.Interfaces;
using TronGame.WinForm;
using TronGame.WinForm.Properties;


namespace TronGame.WinForm
{
    public class Game
    {
        public readonly List<Player> Players;
        public readonly IList<ICommand> Commands;
        public readonly Dictionary<Space, string> Board;
        public string Loser;
        public readonly int Height;
        public readonly int Width;

        public Game(ICommandsFileParser commandsFileParser)
        {
            var commandsFileParser1 = commandsFileParser;
            var playersAndCommands = commandsFileParser1.Parse();
            Players = playersAndCommands.Players;
            Commands = playersAndCommands.Commands;
            Height = 10;
            Width = 10;
            Board = GenerateBoard();
            SetStartingPositions();
        }

        private Dictionary<Space, string> GenerateBoard()
        {
            return Enumerable.Range(0, Width)
                    .SelectMany(val => Enumerable.Range(0, Height).Select(inVal => new Tuple<int, int>(val, inVal)))
                    .Zip(Enumerable.Repeat("-", Width * Height).ToList(),
                        (space, character) => new Tuple<Space, string>(new Space(space.Item1, space.Item2), character))
                        .ToDictionary(t => t.Item1, t => t.Item2, new SpaceEqualityComparer());
        }

        private void SetStartingPositions()
        {
            Players[0].Position = new Space(0, 0);
            Players[1].Position = new Space(9, 9);
            Board[Players[0].Position] = Players[0].Color.Name;
            Board[Players[1].Position] = Players[1].Color.Name;
        }

        public void Play()
        {
            var actionRunner = ActionRunner.Instance();
            while (Commands.Count > 0)
            {
                var player = actionRunner.PerformAction(Commands.First(), Width, Height);
                Commands.RemoveAt(0);
                if (Board[player.Position] == "-")
                {
                    Board[player.Position] = player.Color.Name.ToCharArray()[0].ToString();
                }
                else
                {
                    Loser = player.Name;
                    break;
                }
            }
            PrintLooser();
        }

        public void PrintLooser()
        {
            MessageBoxButtons bns;
            string message;
            const string caption = "Match Results";

            if (Loser == null)
            {
                message = "The match was a Tie!";
                bns = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, bns);
            }
            else
            {
                message = Loser +  " Lost :(";
                bns = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, bns);
            }
                

        }
        
    }
}
