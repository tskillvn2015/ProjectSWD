using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.EF;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Data.Service
{
    public class ProductService : IProductService
    {
        private readonly ShoeserDbContext _context;
        public ProductService(ShoeserDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateProduct(CreateProductViewModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Manufacturer = model.Manufacturer;
            product.Size = model.Size;
            product.Category = model.Category;
            product.Description = model.Description;
            product.Quantity = model.Quantity;
            product.Status = model.Status;
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }
    }
}
