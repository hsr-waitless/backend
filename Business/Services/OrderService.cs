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
        private readonly IDataService data;
        private readonly WaitlessContext context;

        public OrderService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~OrderService()
        {
            context.Dispose();
        }

        public OrderModel CreateOrder(long tableId, string tabletIdentifier)
        {
            var newOrder = new Order();

            newOrder.Table = context.Table
                .FirstOrDefault(t => t.Id == tableId);
            newOrder.Waiter = context.Tablet
                .FirstOrDefault(m => m.Identifier == tabletIdentifier);
            newOrder.OrderStatus = OrderStatus.New;
            newOrder.CreationTime = DateTime.Now;
            newOrder.UpdateTime = newOrder.CreationTime;
            newOrder.PriceOrder = 0;

            context.Add(newOrder);
            context.SaveChanges();

            return  GetOrder(newOrder.Id);
        }

        public IEnumerable<OrderModel> GetOrdersByWaiter(string tabletIdentifier)
        {
            return context.Order
                .Include(m => m.Waiter)
                .Include(m => m.Table)
                .Where(m => m.Waiter.Identifier == tabletIdentifier)
                .Select(m => OrderModel.MapFromDatabase(m))
                .ToList();
        }

        public OrderModel GetOrder(long number)
        {
            var order = context.Order
                .Include(m => m.Table)
                .Include(m => m.Guests)
                .Include(m => m.Positions)
                .Include("Positions.Itemtyp")
                .FirstOrDefault(m => m.Id == number);

            return OrderModel.MapFromDatabase(order);
        }



        public OrderModel DoChangeOrderStatus(long orderId, OrderStatus orderStatus)
        {
            var relevantOrder = context.Order
                .FirstOrDefault(o => o.Id == orderId);
            relevantOrder.OrderStatus = orderStatus;
            context.SaveChanges();

            return GetOrder(orderId);
        }

        public void DoCalulateOrderPrice(long orderId)
        {
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

        public IEnumerable<OrderModel> GetOrdersByStatus(PosStatus status)
        {
            return context.Order
                .Include(o => o.Table)
                .Include(o => o.Positions)
                .Include("Positions.Itemtyp")
                .Where(t => t.Positions.Any(p => p.PosStatus == status))
                .ToList()
                .Select(o =>
                {
                    o.Positions = o.Positions.Where(p => p.PosStatus == status).ToList();
                    return o;
                })
                .Select(m => OrderModel.MapFromDatabase(m));
        }

        
    }
}