﻿using Autofac;
using TronGame.Logic;

namespace TronGame.Console
{
    class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Down>().As<ICommand>();
            builder.RegisterType<Up>().As<ICommand>();
            builder.RegisterType<Left>().As<ICommand>();
            builder.RegisterType<Right>().As<ICommand>();
            builder.RegisterType<CommandsFileParser>().As<ICommandsFileParser>();

        }
        
    }
}
