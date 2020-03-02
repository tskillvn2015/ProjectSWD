﻿using Shoes_Store.Data.EF;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoeserDbContext context;
        private IGenericRepository<Account> accountRepository;
        private IGenericRepository<History> historyRepository;
        private IGenericRepository<Order> orderRepository;
        private IGenericRepository<OrderDetail> orderDetailRepository;
        private IGenericRepository<Product> productRepository;
        public UnitOfWork(ShoeserDbContext context)
        {
            this.context = context;
        }

        #region Repository
        public IGenericRepository<Account> AccountRepository
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(context);
                }
                return accountRepository;
            }
        }

        public IGenericRepository<History> HistoryRepository
        {
            get
            {

                if (this.historyRepository == null)
                {
                    this.historyRepository = new GenericRepository<History>(context);
                }
                return historyRepository;
            }
        }

        public IGenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (this.orderDetailRepository == null)
                {
                    this.orderDetailRepository = new GenericRepository<OrderDetail>(context);
                }
                return orderDetailRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        #endregion

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
