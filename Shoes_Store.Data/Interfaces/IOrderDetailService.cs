using Shoes_Store.Data.ViewModels;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IOrderDetailService
    {
        Task<Object> CreateOrderDetail(createOrderDetailViewModel model);
        Task<Object> DeleteOrderDetail(deleteOrderDetailViewModel model);
        Task<Object> UpdateOrderDetail(updateOrderDetailViewModel model);
        Task<Object> GetAllOrderDetail(searchOrderDetailViewModel model);

        Task<Response> CreateOrderDetailBatch(createOrderDetailViewModel model);
    }
}
