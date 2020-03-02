using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.EF;

namespace Shoes_Store.Data.Service
{
    public class ProductService : IProductService
    {
        private readonly ShoeserDbContext _context;
        public ProductService(ShoeserDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateProduct(Product model)
        {
            _context.Products.Add(model);
            return await _context.SaveChangesAsync();
        }
    }
}
