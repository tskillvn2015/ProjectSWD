using Microsoft.Extensions.Configuration;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
using Shoes_Store.Interfaces;
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
            order.CreatedDate = DateTime.Now;
            order.TotalPrice = model.TotalPrice;
            order.IdAccount = model.IdAccount;
            _unitOfWork.OrderRepository.Add(order);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

       public async Task<int> DeleteOrder(deleteOrderVMs model)
        {
            var result = _unitOfWork.OrderRepository.Get(c=>c.Id.Equals(model.Id));
            if(result.FirstOrDefault() == null)
            {
                throw new Exception("This id order not exist!");
            }
            _unitOfWork.OrderRepository.Delete(result);
            return _unitOfWork.Save();
        }

        
    }
}
