using System;
using System.Collections.Generic;
using System.Text;
using Shoes_Store.Data.Entities;
using System.Threading.Tasks;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Data.Interfaces
{
    public interface IProductService
    {
        Task<Object> ShowProductDetail(Guid id);
        Task<Object> CreateProduct(CreateProductViewModel model);
        Task<Object> UpdateProduct(UpdateProductViewModel model);
        Task<Object> DeleteProduct(DeleteProductViewModel model);
        Task<Object> getProductPagging(SearchProductViewModel model);
    }
}
