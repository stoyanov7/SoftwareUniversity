namespace WebServer.Http.Contracts
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
