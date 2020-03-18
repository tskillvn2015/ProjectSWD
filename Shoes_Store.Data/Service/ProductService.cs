using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.EF;
using Shoes_Store.Data.ViewModels;
using Shoes_Store.Common;
using Shoes_Store.Interfaces;

namespace Shoes_Store.Data.Service
{
    public class ProductService : IProductService
    {
        private readonly IApiResponse _apiResponse;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork,IApiResponse apiResponse)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = apiResponse;
        }
        public async Task<Object> CreateProduct(CreateProductViewModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Manufacturer = model.Manufacturer;
            product.Size = model.Size;
            product.Category = model.Category;
            product.Description = model.Description;
            product.Quantity = model.Quantity;
            product.Status = model.Status;
            product.CreatedAt = DateTime.Now;
            _unitOfWork.ProductRepository.Add(product);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }
    }
}
