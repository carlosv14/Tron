using Autofac;
using TronGame.Logic;
using TronGame.Logic.Interfaces;
using TronGame.Logic.Model;

namespace TronGame.Console
{
    internal class Program
    {
        private static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandsFile>().As<ICommandsFile>();
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
