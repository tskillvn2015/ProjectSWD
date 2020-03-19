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
        Task<Object> ShowProductList();
        Task<Object> ShowProductDetail(ShowProductDetailViewModel model);
        Task<Object> CreateProduct(CreateProductViewModel model);
        Task<Object> SearchProduct(SearchProductViewModel model);
        Task<Object> UpdateProduct(UpdateProductViewModel model);
        Task<Object> DeleteProduct(DeleteProductViewModel model);
    }
}
