using Microsoft.Extensions.Configuration;
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
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiResponse _apiResponse;

        public OrderService(IUnitOfWork unitOfWork, IApiResponse apiResponse)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = apiResponse;
        }

        public async Task<Object> CreateOrder(OrderViewModel model)
        {
            Order order = new Order();
            order.NameOrder = model.NameOrder;
            order.CreatedDate = DateTime.UtcNow;
            order.TotalPrice = model.TotalPrice;
            if(order.TotalPrice < 0)
            {
                return _apiResponse.Error("Total Price " + ShoerserException.OrderException.O01, nameof(ShoerserException.OrderException.O01));
            }
            order.CreatedAt = DateTime.Now;
            //order.IdAccount = model.IdAccount;
            _unitOfWork.OrderRepository.Add(order);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

       public async Task<Object> DeleteOrder(deleteOrderVMs model)
        {
            Order order = _unitOfWork.OrderRepository.GetByID(model.Id);
            order.IsDelete = true;
            _unitOfWork.OrderRepository.Update(order);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        
    }
}
