using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronGame.Logic.Interfaces;

namespace TronGame.Logic.Model
{
    public class CommandsFileModel
    {
        public List<Player> Players { get; set; }
        public IList<ICommand> Commands { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            var commandFileModelToCompare = obj as CommandsFileModel;
            if(commandFileModelToCompare == null)
                return false;
            var playersNameDiff = this.Players.Select(p => p.Name).Except(commandFileModelToCompare.Players.Select(p => p.Name));
            var playersColorDiff =
                this.Players.Select(p => p.Color.Name)
                    .Except(commandFileModelToCompare.Players.Select(p => p.Color.Name));
            result = !playersColorDiff.Any() && !playersNameDiff.Any();
            var commandsDiff =
                this.Commands.Select(c => c.Player.Name)
                    .Except(commandFileModelToCompare.Commands.Select(c => c.Player.Name));
            result &= !commandsDiff.Any();
            return result;
        }
    }
}
