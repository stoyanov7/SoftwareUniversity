using SIS.Framework.Api;

namespace Chushka
{
    using Services;
    using Services.Contracts;
    using SIS.Framework.Services;

    public class Startup : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUserService, UserService>();
            dependencyContainer.RegisterDependency<IProductService, ProductService>();
        }
    }
}