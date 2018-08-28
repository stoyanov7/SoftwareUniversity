namespace ByTheCake.Controllers
{
    using Views.Cake;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class CakeController
    {
        public IHttpResponse Add()
        {
            return new ViewResponse(HttpStatusCode.Ok, new Add());
        }
    }
}