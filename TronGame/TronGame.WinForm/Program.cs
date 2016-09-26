using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using TronGame.Logic;
using TronGame.Logic.Interfaces;

namespace TronGame.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CommandsFile>().As<ICommandsFile>();
            builder.RegisterType<CommandsFileParser>().As<ICommandsFileParser>().WithParameter("fileName", "Moves.txt");
            var container = builder.Build();
            Game game ;

            using (var scope = container.BeginLifetimeScope())
            {
                var parser = scope.Resolve<ICommandsFileParser>();
                game = new Game(parser);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mf = new MainFrame(game);
            Application.Run(mf);

            
        }
    }
}
