namespace ModPanel.Attributes
{
    using SimpleMvc.Framework.Attributes.Security;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class AuthorizeLoginAttribute : PreAuthorizeAttribute
    {
        public override IHttpResponse GetResponse(string message)
        {
            return new RedirectResponse("/users/login");
        }
    }
}