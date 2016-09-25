namespace TronGame.Logic.Interfaces
{
    public interface ICommand
    {
        Player Player { get; set; }
        void Run();
    }
}