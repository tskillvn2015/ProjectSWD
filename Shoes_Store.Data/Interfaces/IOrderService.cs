﻿using Shoes_Store.Data.ViewModels;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IOrderService
    {
        Task<Object> CreateOrder(List<createOrderDetailViewModel> model,Guid id);
        Task<Object> DeleteOrder(deleteOrderVMs model);
        Task<Object> UpdateOrder(updateOrderViewModel model);
        Task<Object> GetAllOrder(searchOrderViewModel model);
        
    }
}
