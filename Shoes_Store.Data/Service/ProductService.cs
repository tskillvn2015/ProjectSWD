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
using Shoes_Store.Ultility.Common;

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
        public async Task<Object> ShowProductList()
        {
            var listProduct = _unitOfWork.ProductRepository.Get();
            var result = _apiResponse.Ok(listProduct);
            return result;
        }
        public async Task<Object> ShowProductDetail(ShowProductDetailViewModel model)
        {
            Product product = _unitOfWork.ProductRepository.GetByID(model.Id);
            if(product == null)
            {
                return _apiResponse.Error(ShoerserException.ProductException.P03, nameof(ShoerserException.ProductException.P03));
            }
            var result = _apiResponse.Ok(product);
            return result;
        }
        public async Task<Object> CreateProduct(CreateProductViewModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Manufacturer = model.Manufacturer;
            product.Size = model.Size;
            if (product.Size <= 0)
            {
                return _apiResponse.Error("Size " + ShoerserException.ProductException.P01, nameof(ShoerserException.ProductException.P01));
            }
            product.Category = model.Category;
            if(product.Category.Length > 200)
            {
              return _apiResponse.Error(ShoerserException.ProductException.P02, nameof(ShoerserException.ProductException.P02));
            }
            product.Description = model.Description;
            product.Quantity = model.Quantity;
            if (product.Quantity <= 0)
            {
                return _apiResponse.Error("Quantity " + ShoerserException.ProductException.P01, nameof(ShoerserException.ProductException.P01));
            }
            product.Status = model.Status;
            product.CreatedAt = DateTime.Now;
            _unitOfWork.ProductRepository.Add(product);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> SearchProduct(SearchProductViewModel model)
        {
            var listProduct = _unitOfWork.ProductRepository.Get(c => c.Name.Equals(model.Name));           
            var result = _apiResponse.Ok(listProduct);
            return result;
        }

        public async Task<Object> UpdateProduct(UpdateProductViewModel model)
        {
            Product product = _unitOfWork.ProductRepository.GetByID(model.Id);
            if (product == null)
            {
                return _apiResponse.Error(ShoerserException.ProductException.P03, nameof(ShoerserException.ProductException.P03));
            }
            product.Name = model.Name;
            product.Manufacturer = model.Manufacturer;
            product.Size = model.Size;
            if (product.Size <= 0)
            {
                return _apiResponse.Error("Size " + ShoerserException.ProductException.P01, nameof(ShoerserException.ProductException.P01));
            }
            product.Category = model.Category;
            if (product.Category.Length > 200)
            {
                return _apiResponse.Error(ShoerserException.ProductException.P02, nameof(ShoerserException.ProductException.P02));
            }
            product.Description = model.Description;
            product.Quantity = model.Quantity;
            if (product.Quantity <= 0)
            {
                return _apiResponse.Error("Quantity " + ShoerserException.ProductException.P01, nameof(ShoerserException.ProductException.P01));
            }
            product.Status = model.Status;
            _unitOfWork.ProductRepository.Update(product);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> DeleteProduct(DeleteProductViewModel model)
        {
            Product product = _unitOfWork.ProductRepository.GetByID(model.Id);
            if (product == null)
            {
                return _apiResponse.Error(ShoerserException.ProductException.P03, nameof(ShoerserException.ProductException.P03));
            }
            product.IsDelete = true;
            _unitOfWork.ProductRepository.Update(product);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }
    }
}
