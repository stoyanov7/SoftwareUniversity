namespace Chushka.Controllers
{
    using Models.BindingModels;
    using Models.Enums;
    using Models.ViewModels;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Create(CreateProductBindingModel model)
        {
            if (!this.IsLoggedIn())
            {
                return this.RedirectToAction("/Users/Login");
            }

            this.productService.CreateProduct(model.Name, model.Price, model.Description, model.ProductType);

            return this.RedirectToHome();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/Users/Login");
            }

            var model = this.productService.ProductDetails(id);
            this.Model.Data["Id"] = model.Id;
            this.Model.Data["Name"] = model.Name;
            this.Model.Data["Type"] = model.Type;
            this.Model.Data["Price"] = model.Price;
            this.Model.Data["Description"] = model.Description;

            return this.View();
        }

        [HttpGet]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Delete(int id)
        {
            if (this.Identity == null)
            {
                return this.RedirectToAction("/Users/Login");
            }

            var model = this.productService.DeleteProductDetails(id);
            this.Model.Data["Name"] = model.Name;
            this.Model.Data["Type"] = model.Type;
            this.Model.Data["Price"] = model.Price;
            this.Model.Data["Description"] = model.Description;

            return this.View();
        }

        [HttpPost]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult Delete(ProductDeleteViewModel model)
        {
            this.productService.DeleteProduct(model.Id);

            return this.RedirectToHome();
        }
    }
}