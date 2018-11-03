namespace Torshia
{
    using SIS.Framework.Api;
    using SIS.Framework.Services;
    using Services;
    using Services.Contracts;

    public class Startup : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();
            dependencyContainer.RegisterDependency<ITasksService, TasksService>();
            dependencyContainer.RegisterDependency<IReportService, ReportService>();
        }
    }
}