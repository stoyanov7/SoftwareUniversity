namespace Banicharnica
{
    using System;
    using AutoMapper;
    using Core;
    using Core.Contracts;
    using Core.Controller;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();
            var engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddDbContext<BanicharnicaDbContext>(o => o.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<BanicharnicaProffile>());

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();
            serviceCollection.AddTransient<IManagerController, ManagerController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
