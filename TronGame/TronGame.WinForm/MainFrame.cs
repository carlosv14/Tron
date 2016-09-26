using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using TronGame.Logic;
using TronGame.Logic.Interfaces;
using TronGame.WinForm.Properties;

namespace TronGame.WinForm
{
    public partial class MainFrame : Form
    {
        private readonly Game _game;

        public MainFrame(Game game)
        {
            InitializeComponent();
            _game = game;
            SetStartingPositions();
            DrawGame();
        }

        private void SetStartingPositions()
        {
            var firstPlayer = true;
            foreach (var player in _game.Players)
            {
                var playerImage = new PictureBox
                {
                    Image = player.Color.Name.Contains("Red") ? Resources.red : Resources.blu
                };
                var x = 7;
                var y = 7;

                if (firstPlayer)
                    firstPlayer = false;
                else
                {
                    x = 321;
                    y = 321;
                }

                var path = new Panel();
                path.Controls.Add(playerImage);
                path.SetBounds(x,y, 32, 32);
                MainPanel.Controls.Add(path);
                path.BringToFront();
            }
        }

        private void DrawGame()
        {
            
            var actionRunner = ActionRunner.Instance();
            while (_game.Commands.Count > 0)
            {
                var playerImage = new PictureBox();
                var player = actionRunner.PerformAction(_game.Commands.First(), _game.Width, _game.Height);
                _game.Commands.RemoveAt(0);
                if (_game.Board[player.Position] == "-")
                {
                    _game.Board[player.Position] = player.Color.Name.ToCharArray()[0].ToString();
                    playerImage.Image = player.Color.Name == "Red" ? Resources.red : Resources.blu;
                    AddNewPath(playerImage, player.Position.XPos, player.Position.YPos);
                }
                else
                {
                    _game.Loser = player.Name;
                    break;
                }
            }
            _game.PrintLooser();
        }

        public void AddNewPath(Control playerPath, int x, int y)
        {
            var posY = y == 0 ? 41 : y*35+6;
            var posX = x == 0 ? 7 : x*35+6;
            var path = new Panel();
            path.Controls.Add(playerPath);
            path.SetBounds(posX, posY, 32, 32);
            MainPanel.Controls.Add(path);
            path.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
