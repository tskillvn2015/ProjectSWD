using Shoes_Store.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderViewModel model);
        Task<int> DeleteOrder(deleteOrderVMs model);
        


    }
}
