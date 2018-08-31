namespace MeTube.Controllers
{
    using System.Linq;
    using Attributes;
    using Models;
    using Models.BindingModels;
    using Models.ViewModels;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class TubeController : BaseController
    {
        [HttpGet]
        [AuthorizeLogin]
        public IActionResult Upload() => this.View();

        [HttpPost]
        [AuthorizeLogin]
        public IActionResult Upload(TubeUploadBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                return this.BuildErrorView();
            }

            using (this.Context)
            {
                var youTubeId = this.GetYouTubeIdFromLink(model.YouTubeLink);

                if (youTubeId == null)
                {
                    return this.BuildErrorView();
                }

                var tube = new Tube
                {
                    Title = model.Title,
                    Author = model.Author,
                    Description = model.Description,
                    YouTubeId = youTubeId,
                    UploaderId = this.DbUser.Id
                };

                this.Context.Tubes.Add(tube);
                this.Context.SaveChanges();

                return this.RedirectToAction($"/tube/details?id={tube.Id}");
            }
        }

        [HttpGet]
        [AuthorizeLogin]
        public IActionResult Details(int id)
        {
            using (this.Context)
            {
                var tube = this.Context.Tubes.Find(id);

                if (tube == null)
                {
                    return this.RedirectToHome();
                }

                tube.Views++;
                this.Context.SaveChanges();

                var model = new[] { tube }
                    .Select(TubeDetailsViewModel.FromTube)
                    .Single();

                this.Model.Data["title"] = model.Title;
                this.Model.Data["youTubeId"] = model.YouTubeId;
                this.Model.Data["author"] = model.Author;
                this.Model.Data["views"] = $"{model.Views} View{(model.Views == 1 ? "" : "s")}";
                this.Model.Data["description"] = model.Description;

                return this.View();
            }
        }

        private string GetYouTubeIdFromLink(string youTubeLink)
        {
            string youTubeId = null;

            if (youTubeLink.Contains("youtube.com"))
            {
                youTubeId = youTubeLink.Split("?v=")[1];
            }
            else if (youTubeLink.Contains("youtu.be"))
            {
                youTubeId = youTubeLink.Split("/").Last();
            }

            return youTubeId;
        }
    }
}