using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Commands;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;

            // Autofac skanuje wszystkie klasy i tworzy ich instancje 
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            // powyższy kod robi to co poniższy tylko dla wszystkich command
            // builder.RegisterType<CreateUserHandler>()
            //     .As<ICommandHandler<CreateUser>>()
            //     .InstancePerLifetimeScope;

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
        }
    }
}