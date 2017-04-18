using Database;
using Database.Models;
using System;
using System.Linq;
using Business.Models;

namespace Business.Services
{
    public class CreateOrderService
    {
        private readonly WaitlessContext context;

        public CreateOrderService(WaitlessContext context)
        {
            this.context = context;
        }

        public OrderModel CreateOrder(long tableId, string tabletIdentifier)
        {
            var newOrder = new Order();

            newOrder.Table = context.Table
            .FirstOrDefault(m => m.Id == tableId);
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
                Number = newOrder.Number,
                OrderStatus = newOrder.OrderStatus,
                CreationTime = newOrder.CreationTime,
                UpdateTime = newOrder.UpdateTime,
                PriceOrder = newOrder.PriceOrder,
            };
        }
    }
}

