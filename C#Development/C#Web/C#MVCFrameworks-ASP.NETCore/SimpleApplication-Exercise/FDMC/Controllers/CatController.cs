namespace FDMC.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;

    public class CatController : Controller
    {
        private readonly ICatService catService;

        public CatController(ICatService catService)
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

        [HttpGet]
        public IActionResult Add() => this.View();

        [HttpPost]
        public IActionResult Add(Cat cat)
        {
            if (this.ModelState.IsValid)
            {
                this.catService.AddCat(cat);
                return this.RedirectToAction("Details", "Cat", new { id = cat.Id });
            }

            return this.View();
        }
    }
}