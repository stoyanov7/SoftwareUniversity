namespace MishMash.Controllers
{
    using Models.BindingModels;
    using Models.Enums;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;

    public class ChannelsController : BaseController
    {
        private readonly IChannelService channelService;

        public ChannelsController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/Users/Login");
            }

            var model = this.channelService.ChannelDetails(id);
            this.Model.Data["Channel"] = model.Channel;
            this.Model.Data["Type"] = model.Type;
            this.Model.Data["Followers"] = model.Followers;
            this.Model.Data["Tags"] = model.Tags;
            this.Model.Data["Description"] = model.Description;

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Followed()
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/users/login");
            }
 
            this.Model["Followed"] = this.channelService.FollowedChannels(this.Identity.Username);
            return this.View();
        }

        [HttpGet]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Create(CreateChannelBindingModel model)
        {
            if (!this.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            this.channelService.CreateChannel(model.Name, model.Description, model.ChannelType, model.Tags);

            return this.RedirectToHome();
        }
    }
}