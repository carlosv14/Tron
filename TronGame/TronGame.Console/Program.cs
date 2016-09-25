using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronGame.Logic;

namespace TronGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new Game(new CommandsFileParser("Moves.txt"));
            game.Play();
        }
    }
}
