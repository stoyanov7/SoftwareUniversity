namespace Chushka.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enums;
    using Models.ViewModels;

    public class ProductService : IProductService
    {
        private readonly ChushkaContext context;

        public ProductService(ChushkaContext context)
        {
            this.context = context;
        }

        public void CreateProduct(string name, string price, string description, string productType)
        {
            var product = new Product
            {
                Name = name,
                Price = decimal.Parse(price),
                Description = description,
                Type = (ProductType) Enum.Parse(typeof(ProductType), productType, true)
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public ProductDetailsViewModel ProductDetails(int id)
        {
            return this.context
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price.ToString("F2"),
                    Type = p.Type.ToString()
                })
                .FirstOrDefault();
        }

        public ProductDeleteViewModel DeleteProductDetails(int id)
        {
            return this.context
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDeleteViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price.ToString("F2"),
                    Type = p.Type.ToString()
                })
                .FirstOrDefault();
        }

        public void DeleteProduct(int id)
        {
            var product = this.context
                .Products
                .FirstOrDefault(p => p.Id == id);

            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }

        public ICollection<AllOrdersViewModel> GetAllOrders()
        {
            var allOrdersViewModel = new List<AllOrdersViewModel>();

             var orders = this.context
                .Orders
                .Include(p => p.Product)
                .Include(c => c.Client)
                .ToArray();

            for (var i = 0; i < orders.Length; i++)
            {
                var order = new AllOrdersViewModel
                {
                    Index = i + 1,
                    OrderId = orders[i].Id,
                    Customer = orders[i].Client.FullName,
                    OrderedOn = orders[i].OrderOn.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    Product = orders[i].Product.Name
                };

                allOrdersViewModel.Add(order);
            }

            return allOrdersViewModel;
        }
    }
}