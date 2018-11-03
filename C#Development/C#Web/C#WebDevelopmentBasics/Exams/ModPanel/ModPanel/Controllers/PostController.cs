namespace ModPanel.Controllers
{
    using Attributes;
    using Models.BindingModels;
    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class PostController : BaseController
    {
        private const string CreateError = "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>";

        private readonly IPostService postService;

        public PostController() => this.postService = new PostService();

        [HttpGet]
        [AuthorizeLogin]
        public IActionResult Create() => this.View();

        [HttpPost]
        [AuthorizeLogin]
        public IActionResult Create(PostBindingModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(CreateError);
                return this.View();
            }

            this.postService.Create(model.Title, model.Content, this.DbUser.Id);

            return this.RedirectToHome();
        }
    }
}