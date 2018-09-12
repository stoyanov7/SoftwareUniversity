namespace FDMC.Controllers
{
    using System.Linq;
    using System.Text;
    using Attributes;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.BindingModels;
    using Models.ViewModels;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class KittenController : HomeController
    {
        [HttpGet]
        [AuthorizeLogin]
        public IActionResult Add() => this.View();

        [HttpPost]
        [AuthorizeLogin]
        public IActionResult Add(KittenAddBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                return this.BuildErrorView();
            }

            using (this.Context)
            {
                var breed = this.Context
                    .Breeds
                    .FirstOrDefault(b => b.Name == model.Breed);

                if (breed == null)
                {
                    this.Model.Data["error"] = "Invalid breed";
                    return this.View();
                }

                var kitten = new Kitten
                {
                    Name = model.Name,
                    Age = model.Age,
                    Breed = breed
                };

                this.Context.Kittens.Add(kitten);
                this.Context.SaveChanges();

                return this.RedirectToAction("/kittens/all");
            }
        }

        [HttpGet]
        [AuthorizeLogin]
        public IActionResult All()
        {
            var kittens = this.Context
                .Kittens
                .Include(k => k.Breed)
                .Select(KittenAllViewModel.FromKitten)
                .Select(vm =>
                    $@"<div class=""col-4"">
                        <img class=""img-thumbnail"" src=""https://images.pexels.com/photos/20787/pexels-photo.jpg?auto=compress&cs=tinysrgb&h=350"" alt=""{vm.Name}'s photo"" />
                        <div>
                            <h5>Name: {vm.Name}</h5>
                            <h5>Age: {vm.Age}</h5>
                            <h5>Breed: {vm.Breed}</h5>
                        </div>
                    </div>")
                .ToList();

            var sb = new StringBuilder();
            sb.Append(@"<div class=""row text-center"">");

            for (var i = 0; i < kittens.Count; i++)
            {
                sb.Append(kittens[i]);

                if (i % 3 == 2)
                {
                    sb.Append(@"</div><div class=""row text-center"">");
                }
            }

            sb.Append("</div>");

            this.Model.Data["kittens"] = sb.ToString();
            return this.View();
        }
    }
}