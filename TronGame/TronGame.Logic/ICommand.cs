namespace TronGame.Logic
{
    public interface ICommand
    {
        Player Player { get; set; }
        void Run();
    }
}