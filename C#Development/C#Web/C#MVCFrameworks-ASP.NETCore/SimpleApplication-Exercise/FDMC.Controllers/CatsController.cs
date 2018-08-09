namespace FDMC.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class CatsController : Controller
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

       
        public IActionResult Details(int id)
        {
            var cat = this.catService.FindCatById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            return this.View(cat);
        }
    }
}