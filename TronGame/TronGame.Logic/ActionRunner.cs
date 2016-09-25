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
            command.Player.Position.XPos %= maxWidth;
            command.Player.Position.YPos %= maxHeight;
            return command.Player;
        }
    }
}