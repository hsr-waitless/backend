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
                .Include(m => m.Table)
                .Where(m => m.Waiter.Identifier == tabletIdentifier)
                .Select(m => new OrderModel
                {
                    Number = m.Id,
                    Table = m.Table.Name,
                    OrderStatus = m.OrderStatus,
                    CreationTime = m.CreationTime,
                    UpdateTime = m.UpdateTime,
                    PriceOrder = m.PriceOrder,
                    Positions = new List<object>()
                });
        }

        public OrderModel GetOrder(long number)
        {
            return context.Order
                .Include(m => m.Table)
                .Where(m => m.Id == number)
                .Select(m => new OrderModel
                {
                    Number = m.Id,
                    Table = m.Table.Name,
                    OrderStatus = m.OrderStatus,
                    CreationTime = m.CreationTime,
                    UpdateTime = m.UpdateTime,
                    PriceOrder = m.PriceOrder,
                    Positions = new List<object>()
                })
                .FirstOrDefault();
        }
    }
}