using Microsoft.Extensions.Configuration;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
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
       
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> CreateOrder(OrderViewModel model)
        {
            var result = _unitOfWork.OrderRepository.Get(c => c.NameOrder.Equals(model.NameOrder));
            if(result.FirstOrDefault() != null)
            {
                throw new Exception("This name order already exist!");
            }
            var order = new Order
            {
                NameOrder = model.NameOrder,
                CreatedDate = model.CreatedDate,
                //Accounts = model.Accounts,
                TotalPrice = model.TotalPrice,
                IdAccount = model.IdAccount,
                //OrderDetails = model.OrderDetails,
            };
            _unitOfWork.OrderRepository.Add(order);
            return _unitOfWork.Save();
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
