using TronGame.Logic.Interfaces;

namespace TronGame.Logic
{
    public class ActionRunner
    {
        private static ActionRunner _instance;

        protected ActionRunner()
        {

        }

        public static ActionRunner Instance()
        {
            return _instance ?? (_instance = new ActionRunner());
        }

        public Player PerformAction(ICommand command, int maxWidth, int maxHeight)
        {
            command.Run();
            command.Player.Position.XPos= command.Player.Position.XPos % maxWidth;
            command.Player.Position.YPos= command.Player.Position.YPos % maxHeight;
            if (command.Player.Position.XPos < 0)
                command.Player.Position.XPos = maxWidth - 1;
            if (command.Player.Position.YPos < 0)
                command.Player.Position.YPos = maxHeight - 1;
            return command.Player;
        }
    }
}