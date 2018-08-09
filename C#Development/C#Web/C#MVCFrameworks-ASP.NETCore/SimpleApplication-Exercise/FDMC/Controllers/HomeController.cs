namespace FDMC.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class HomeController : Controller
    {
        private readonly ICatService catService;

        public HomeController(ICatService catService)
        {
            this.catService = catService;
        }

        public FdmcContext Context { get; set; }

        public IActionResult Index()
        {
            var cats = this.catService.GetCatList();

            return this.View(cats);
        }
    }
}
