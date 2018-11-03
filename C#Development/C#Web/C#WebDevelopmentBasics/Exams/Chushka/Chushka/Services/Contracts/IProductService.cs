namespace Chushka.Services.Contracts
{
    using System.Collections.Generic;
    using Models.ViewModels;

    public interface IProductService
    {
        void CreateProduct(string name, string price, string description, string productType);

        ProductDetailsViewModel ProductDetails(int id);

        ProductDeleteViewModel DeleteProductDetails(int id);

        void DeleteProduct(int id);

        ICollection<AllOrdersViewModel> GetAllOrders();
    }
}