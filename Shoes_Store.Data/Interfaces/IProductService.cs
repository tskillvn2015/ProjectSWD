using System;
using System.Collections.Generic;
using System.Text;
using Shoes_Store.Data.Entities;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProduct(Product model);
    }
}
