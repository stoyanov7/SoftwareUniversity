namespace MeTube.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.ViewModels;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;


    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                IList<TubeIndexViewModel> tubes;
                using (this.Context)
                {
                    tubes = this.Context
                        .Tubes
                        .Select(TubeIndexViewModel.FromTube)
                        .ToList();
                }

                var sb = new StringBuilder();
                sb.Append(@"<div class=""row text-center"">");

                for (var i = 0; i < tubes.Count; i++)
                {
                    var tube = tubes[i];
                    sb.Append(
                        $@"<div class=""col-4"">
                            <img class=""img-thumbnail tube-thumbnail"" src=""https://img.youtube.com/vi/{tube.YouTubeId}/0.jpg"" alt=""{tube.Title}"" />
                            <div>
                                <h5>{tube.Title}</h5>
                                <h5>{tube.Author}</h5>
                            </div>
                        </div>");

                    if (i % 3 == 2)
                    {
                        sb.Append(@"</div><div class=""row text-center"">");
                    }
                }

                sb.Append("</div>");

                this.Model.Data["result"] = sb.ToString();
            }
            else
            {
                this.Model.Data["result"] =
                    @"<div class=""jumbotron"">
                        <p class=""h1 display-3"">Welcome to MeTube&trade;!</p>
                        <p class=""h3"">The simplest, easiest to use, most comfortable Multimedia Application.</p>
                        <hr class=""my-3"">
                        <p><a href=""/users/login"">Login</a> if you have an account or <a href=""/users/register"">Register</a> now and start tubing.</p>
                    </div>";
            }

            return this.View();
        }
    }
}