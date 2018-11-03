namespace MishMash
{
    using Services;
    using Services.Contracts;
    using SIS.Framework.Api;
    using SIS.Framework.Services;

    public class Startup : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUserService, UserService>();   
            dependencyContainer.RegisterDependency<IChannelService, ChannelService>();
        }
    }
}