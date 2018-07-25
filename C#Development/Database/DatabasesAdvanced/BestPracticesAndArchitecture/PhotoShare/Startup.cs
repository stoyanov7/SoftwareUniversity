namespace PhotoShare
{
    using System;
    using System.IO;
    using AutoMapper;
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

            serviceCollection.AddDbContext<PhotoShareContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<PhotoShareProfile>());

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();

            //serviceCollection.AddTransient<IAlbumRoleService, AlbumRoleService>();
            //serviceCollection.AddTransient<IPictureService, PictureService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
