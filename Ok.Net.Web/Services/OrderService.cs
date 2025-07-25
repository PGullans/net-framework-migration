﻿using Ok.Framework.Db.Model;
using Ok.Framework.Db.Repository;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ok.Net.Web.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IQueryable<Order> GetAll()
        {
            return _orderRepository.GetAllAsNoTracking();
        }

        public Order GetById(Guid orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public Order Upsert(Order order)
        {


            return order;
        }

        public void Delete(Guid Id)
        {

        }
    }
}