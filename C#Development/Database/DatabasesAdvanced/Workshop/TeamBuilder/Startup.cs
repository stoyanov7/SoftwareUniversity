namespace TeamBuilder
{
    using System;
    using System.IO;
    using Core;
    using Core.Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var service = ConfigureServices();
            var engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddDbContext<TeamBuilderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IEventService, EventService>();
            serviceCollection.AddTransient<ITeamService, TeamService>();
            serviceCollection.AddTransient<IUserTeamService, UserTeamService>();
            serviceCollection.AddTransient<IInvitationService, InvitationService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
