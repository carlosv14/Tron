using Autofac;
using TronGame.Logic;
using TronGame.Logic.Interfaces;

namespace TronGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandsFileParser>().As<ICommandsFileParser>().WithParameter("fileName", "Moves.txt");
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var parser = scope.Resolve<ICommandsFileParser>();
                var game = new Game(parser);
                game.Play();
                System.Console.ReadLine();
            }

           
        }
    }
}
