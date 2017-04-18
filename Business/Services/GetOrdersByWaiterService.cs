using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class GetOrdersByWaiterService
    {
        private readonly WaitlessContext context;

        public GetOrdersByWaiterService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderModel> GetOrders(string tabletIdentifier)
        {
            return context.Order
            .Include(m => m.Waiter)
            .Where(m => m.Waiter.Identifier == tabletIdentifier)
            .ToList().Select(m => new OrderModel
                {
                    Number = m.Number,
                    OrderStatus = m.OrderStatus,
                    CreationTime = m.CreationTime,
                    UpdateTime = m.UpdateTime,
                    PriceOrder = m.PriceOrder,
                });
        }
    }
}

