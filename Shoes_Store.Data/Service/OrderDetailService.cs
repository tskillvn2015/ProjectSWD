using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
using Shoes_Store.Interfaces;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiResponse _apiResponse;

        public OrderDetailService(IUnitOfWork unitOfWork, IApiResponse apiResponse)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = apiResponse;
        }
        public async Task<Object> CreateOrderDetail(createOrderDetailViewModel model)
        {
            OrderDetail orderdetail = new OrderDetail();
            orderdetail.Quantity = model.Quantity;
            if (orderdetail.Quantity <0)
            {
                return _apiResponse.Error(ShoerserException.OrderDetailException.OD01, nameof(ShoerserException.OrderDetailException.OD01));
            }
            orderdetail.IdProduct = model.IdProduct;
            orderdetail.IdOrder = model.IdOrder;
            orderdetail.CreatedAt = DateTime.UtcNow;
            _unitOfWork.OrderDetailRepository.Add(orderdetail);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> DeleteOrderDetail(deleteOrderDetailViewModel model)
        {
            OrderDetail orderdetail = _unitOfWork.OrderDetailRepository.GetByID(model.Id);
            orderdetail.IsDelete = true;
            _unitOfWork.OrderDetailRepository.Update(orderdetail);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> GetAllOrderDetail(searchOrderDetailViewModel model)
        {
            var data = _unitOfWork.OrderDetailRepository.Get(c => (model.Id == null || c.Id.ToString().Contains(model.Id.ToString())) && c.IsDelete == false);
            
            int totalRow = data.Count();

            var dataWithPage = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize).Select(c => new OrderDetailViewModel()
            {
                Id = c.Id,
                IdProduct = c.IdProduct,
                IdOrder = c.IdOrder,
                Quantity = c.Quantity,
                CreatedAt = c.CreatedAt
            }).ToList();
            var result = new PagedResult<OrderDetailViewModel>
            {
                PageSize = model.PageSize,
                PageIndex = model.PageIndex,
                TotalRecord = totalRow,
                Items = dataWithPage
            };
            return _apiResponse.Ok(result);
        }

        public async Task<Object> UpdateOrderDetail(updateOrderDetailViewModel model)
        {
            OrderDetail orderdetail = _unitOfWork.OrderDetailRepository.GetByID(model.Id);
            orderdetail.IdOrder = model.IdOrder;
            orderdetail.IdProduct = model.IdProduct;
            orderdetail.CreatedAt = model.CreatedAt;
            orderdetail.Quantity = model.Quantity;
            if(orderdetail.Quantity < 0)
            {
                return _apiResponse.Error(ShoerserException.OrderDetailException.OD01, nameof(ShoerserException.OrderDetailException.OD01));
            }
            _unitOfWork.OrderDetailRepository.Update(orderdetail);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }
    }
}
