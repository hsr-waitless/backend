using Database;
using Database.Models;
using System;
using System.Linq;
using Business.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class OrderService
    {
        private readonly WaitlessContext context;

        public OrderService(WaitlessContext context)
        {
            this.context = context;
        }

        public OrderModel CreateOrder(long tableId, string tabletIdentifier)
        {
            var newOrder = new Order();

            newOrder.TableId = tableId;
            newOrder.Waiter = context.Tablet
                .FirstOrDefault(m => m.Identifier == tabletIdentifier);
            newOrder.OrderStatus = OrderStatus.New;
            newOrder.CreationTime = DateTime.Now;
            newOrder.UpdateTime = newOrder.CreationTime;
            newOrder.PriceOrder = 0;

            context.Add(newOrder);
            context.SaveChanges();

            return new OrderModel
            {
                Number = newOrder.Id,
                OrderStatus = newOrder.OrderStatus,
                CreationTime = newOrder.CreationTime,
                UpdateTime = newOrder.UpdateTime,
                PriceOrder = newOrder.PriceOrder,
            };
        }
        public IEnumerable<OrderModel> GetOrdersByWaiter(string tabletIdentifier)
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
                    Positions = new List<object>(),
                    Guests = m.Guests
                })
                .FirstOrDefault();
        }

        public OrderModel DoChangeOrderStatus(long orderId, OrderStatus orderStatus)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            relevantOrder.OrderStatus = orderStatus;
            context.SaveChanges();

            // Event fehlt, der alle Tablets benachrichtigt
            // TabletHub.GetTabletsByModeRequest

            return GetOrder(orderId);
        }
    }
}

