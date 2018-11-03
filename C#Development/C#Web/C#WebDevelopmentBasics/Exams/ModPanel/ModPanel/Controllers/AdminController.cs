namespace ModPanel.Controllers
{
    using System.Linq;
    using Models.BindingModels;
    using Services;
    using Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class AdminController : BaseController
    {
        private const string EditError = "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>";

        private readonly IUserService userService;
        private readonly IPostService postService;

        public AdminController()
        {
            this.userService = new UserService();
            this.postService = new PostService();
        }

        [HttpGet]
        public IActionResult Users()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var rows = this.userService
                .All()
                .Select(u => $@"
                    <tr>
                        <td>{u.Id}</td>
                        <td>{u.Email}</td>
                        <td>{u.Position.ToFriendlyName()}</td>
                        <td>{u.Posts}</td>
                        <td>
                            {(u.IsApproved ? string.Empty : $@"<a class=""btn btn-primary btn-sm"" href=""/admin/approve?id={u.Id}"">Approve</a>")}
                        </td>
                    </tr>");

            this.Model.Data["users"] = string.Join(string.Empty, rows);

            return this.View();
        }

        public IActionResult Approve(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            this.userService.Approve(id);

            return this.RedirectToAction("/admin/users");
        }

        public IActionResult Posts()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var rows = this.postService
                .All()
                .Select(p => $@"
                    <tr>
                        <td>{p.Id}</td>
                        <td>{p.Title}</td>
                        <td>
                            <a class=""btn btn-warning btn-sm"" href=""/admin/edit?id={p.Id}"">Edit</a>
                            <a class=""btn btn-danger btn-sm"" href=""/admin/delete?id={p.Id}"">Delete</a>
                        </td>
                    </tr>");

            this.Model.Data["posts"] = string.Join(string.Empty, rows);

            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var post = this.postService.GetById(id);

            if (post == null)
            {
                return this.RedirectToHome();
            }

            this.Model.Data["title"] = post.Title;
            this.Model.Data["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(int id, PostBindingModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(EditError);
                return this.View();
            }

            this.postService.Update(id, model.Title, model.Content);

            return this.RedirectToAction("/admin/posts");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var post = this.postService.GetById(id);

            if (post == null)
            {
                return this.RedirectToHome();
            }

            this.Model.Data["title"] = post.Title;
            this.Model.Data["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(int id, PostBindingModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }
            
            this.postService.Delete(id);

            return this.RedirectToAction("/admin/posts");
        }
    }
}