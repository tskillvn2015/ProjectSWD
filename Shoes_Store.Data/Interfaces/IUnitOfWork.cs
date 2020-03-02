using Shoes_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<History> HistoryRepository { get; }
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        int Save();
    }
}
