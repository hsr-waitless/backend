using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class GetOrdersByWaiterService
    {
        private WaitlessContext context;

        public GetOrdersByWaiterService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderModel> GetOrders(int waiterId)
        {
            return context.Order
            .Where(m => m.Waiter.Id == waiterId)
            .ToList().Select(m =>
            {
                return new OrderModel
                {
                    Number = m.Number,
                    OrderStatus = m.OrderStatus,
                    CreationTime = m.CreationTime,
                    UpdateTime = m.UpdateTime,
                    PriceOrder = m.PriceOrder,
                };
            });
        }
    }
}

