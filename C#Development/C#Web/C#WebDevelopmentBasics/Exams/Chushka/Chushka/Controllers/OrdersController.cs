namespace Chushka.Controllers
{
    using Models.Enums;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;

    public class OrdersController : BaseController
    {
        private readonly IProductService productService;

        public OrdersController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Authorize(nameof(RoleType.Admin))]
        public IActionResult All()
        {
            var model = this.productService.GetAllOrders();
            this.Model["AllOrders"] = model;

            return this.View();
        }
    }
}