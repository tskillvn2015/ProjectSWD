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
using Shoes_Store.Ultility.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shoes_Store.Data.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiResponse _apiResponse;

        public OrderService(IUnitOfWork unitOfWork, IApiResponse apiResponse)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = apiResponse;
        }
        public async Task<Object> CreateOrder(List<createOrderDetailViewModel> listModel, Guid IdAccount)
        {

            var account = _unitOfWork.AccountRepository.Get(x => x.IsDelete == false && x.Id == IdAccount).FirstOrDefault();
            if (account == null)
            {
                return _apiResponse.Error(ShoerserException.AccountException.A02, nameof(ShoerserException.AccountException.A02));
            }
            if (listModel.Count() <= 0)
            {
                return _apiResponse.Error(ShoerserException.OrderException.O02, nameof(ShoerserException.OrderException.O02));
            }
            var totalPrice = 0;
            foreach (var item in listModel)
            {
                var product = _unitOfWork.ProductRepository.Get(x => x.IsDelete == false && x.Id == item.IdProduct).FirstOrDefault();
                if (product != null)
                {
                    totalPrice += (product.Price * item.Quantity);
                }
            }

            Order order = new Order();
            order.NameOrder = account.Username;
            order.TotalPrice = totalPrice;
            order.CreatedAt = DateTime.Now;
            order.IdAccount = IdAccount;
            var addedOrder =_unitOfWork.OrderRepository.Add(order);
            listModel =listModel.Select(x => new createOrderDetailViewModel
            {
                IdOrder = addedOrder.Entity.Id,
                IdProduct = x.IdProduct,
                Quantity = x.Quantity,
            }).ToList();
            foreach (var item in listModel)
            {
                var checkBatch = await CreateOrderDetailBatch(item);
                if (!checkBatch.Code.Equals("200"))
                {
                    return checkBatch;
                }
            }

            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }
        public async Task<Response> CreateOrderDetailBatch(createOrderDetailViewModel model)
        {
            if (model.Quantity < 0)
            {
                return _apiResponse.Error(ShoerserException.OrderDetailException.OD01, nameof(ShoerserException.OrderDetailException.OD01));
            }

            var product = _unitOfWork.ProductRepository.Get(x => x.IsDelete == false && x.Id == model.IdProduct).FirstOrDefault();
            if (product == null)
            {
                return _apiResponse.Error(ShoerserException.ProductException.P03, nameof(ShoerserException.ProductException.P03));
            }
            if (model.Quantity > product.Quantity)
            {
                return _apiResponse.Error(ShoerserException.OrderDetailException.OD02, nameof(ShoerserException.OrderDetailException.OD02));
            }


            OrderDetail orderdetail = new OrderDetail();
            orderdetail.Quantity = model.Quantity;

            orderdetail.IdProduct = model.IdProduct;
            orderdetail.IdOrder = model.IdOrder;
            orderdetail.CreatedAt = DateTime.UtcNow;
            product.Quantity -= model.Quantity;
            _unitOfWork.OrderDetailRepository.Add(orderdetail);
            _unitOfWork.ProductRepository.Update(product);
            return _apiResponse.Ok("Success Add batch order detail");
        }
        public async Task<Object> DeleteOrder(deleteOrderVMs model)
        {
            Order order = _unitOfWork.OrderRepository.GetByID(model.Id);
            order.IsDelete = true;
            _unitOfWork.OrderRepository.Update(order);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> UpdateOrder(updateOrderViewModel model)
        {
            Order order = _unitOfWork.OrderRepository.GetByID(model.Id);
            order.NameOrder = model.NameOrder;
            order.TotalPrice = model.TotalPrice;
            if (order.TotalPrice < 0)
            {
                return _apiResponse.Error("Total Price " + ShoerserException.OrderException.O01, nameof(ShoerserException.OrderException.O01));
            }
            order.IdAccount = model.IdAccount;
            _unitOfWork.OrderRepository.Update(order);
            var result = _apiResponse.Ok(_unitOfWork.Save());
            return result;
        }

        public async Task<Object> GetAllOrder(searchOrderViewModel model)
        {
            var data = _unitOfWork.OrderRepository.Get(c => (model.NameOrder == null || c.NameOrder.Contains(model.NameOrder)) &&
                                                               (c.IsDelete == false));
            int totalRow = data.Count();

            var dataWithPage = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize).Select(c => new OrderViewModel()
            {
                Id = c.Id,
                NameOrder = c.NameOrder,
                TotalPrice = c.TotalPrice,
                IdAccount = c.IdAccount
            }).ToList();
            var result = new PagedResult<OrderViewModel>
            {
                PageSize = model.PageSize,
                PageIndex = model.PageIndex,
                TotalRecord = totalRow,
                Items = dataWithPage
            };

            return _apiResponse.Ok(result);
        }


    }
}
