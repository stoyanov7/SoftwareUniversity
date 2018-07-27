namespace PhotoShare.Client
{
	using System;
	using System.IO;
	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Data;
	using PhotoShare.Core;
	using PhotoShare.Core.Contracts;
	using Services;
	using Services.Contracts;

	public class Startup
	{
		public static void Main()
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

			serviceCollection.AddDbContext<PhotoShareContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<PhotoShareProfile>());

			serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
			serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();

			serviceCollection.AddTransient<IAlbumRoleService, AlbumRoleService>();
			serviceCollection.AddTransient<IPictureService, PictureService>();
		    serviceCollection.AddTransient<IAlbumTagService, AlbumTagService>();
		    serviceCollection.AddTransient<IPictureService, PictureService>();
		    serviceCollection.AddTransient<ITagService, TagService>();
		    serviceCollection.AddTransient<IUserService, UserService>();
		    serviceCollection.AddTransient<ITownService, TownService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

			return serviceProvider;
		}
	}
}