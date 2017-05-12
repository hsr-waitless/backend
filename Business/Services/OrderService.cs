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

            return OrderModel.MapFromDatabase(newOrder);
        }

        public IEnumerable<OrderModel> GetOrdersByWaiter(string tabletIdentifier)
        {
            return context.Order
                .Include(m => m.Waiter)
                .Include(m => m.Table)
                .Where(m => m.Waiter.Identifier == tabletIdentifier)
                .Select(m => OrderModel.MapFromDatabase(m));
        }

        public OrderModel GetOrder(long number)
        {
            return context.Order
                .Include(m => m.Table)
                .Include(m => m.Guests)
                .Include(m => m.Positions)
                .Include("Positions.Itemtyp")
                .Where(m => m.Id == number)
                .Select(m => OrderModel.MapFromDatabase(m))
                .FirstOrDefault();
        }



        public OrderModel DoChangeOrderStatus(long orderId, OrderStatus orderStatus)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            relevantOrder.OrderStatus = orderStatus;
            context.SaveChanges();

            return GetOrder(orderId);
        }

        public void DoCalulateOrderPrice(long orderId) {
            var relevantOrder = context.Order
                .Include(o => o.Positions)
                .FirstOrDefault(r => r.Id == orderId);

            if (relevantOrder == null)
            {
                return;
            }

            relevantOrder.PriceOrder = 0;
            foreach (var position in relevantOrder.Positions)
            {
                relevantOrder.PriceOrder += position.PricePos;
            }
            context.SaveChanges();
        }

        public IEnumerable<OrderModel> GetOrdersByStatus(OrderStatus status)
        {
            return context.Order
                .Include(o => o.Table)
                .Include(o => o.Positions)
                .Include("Positions.Itemtyp")
                .Where( t =>t.OrderStatus == status)
                .Select(m => OrderModel.MapFromDatabase(m));
        }
    }
}