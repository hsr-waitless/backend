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
                .Where(m => m.Id == number)
                .Select(m => OrderModel.MapFromDatabase(m))
                .FirstOrDefault();
        }

        public bool AddOrderPos(long orderId, long itemTypeId) {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return false;
            }

            var position = new OrderPos()
            {
                Number = context.OrderPos
                             .Where(op => op.OrderId == orderId)
                             .Select(op => op.Number)
                             .DefaultIfEmpty(0)
                             .Max() + 1,
                CreationDate = DateTime.Now,
                PosStatus = PosStatus.New,
                ItemtypId = itemTypeId,
                OrderId = orderId,
                Amount = 1

            };

            relevantOrder.Positions.Add(position);
            context.SaveChanges();
            return true;
        }

        public bool RemoveOrderPos(long orderId, long positionId)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return false;
            }

            var relevantPos = relevantOrder.Positions.FirstOrDefault(p => p.Id == positionId);
            if (relevantPos == null)
            {
                return false;
            }

            relevantOrder.Positions.Remove(relevantPos);
            context.SaveChanges();
            return true;
        }

        public OrderModel DoChangeOrderStatus(long orderId, OrderStatus orderStatus)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            relevantOrder.OrderStatus = orderStatus;
            context.SaveChanges();
            
            return GetOrder(orderId);
        }

        public void DoCalulateOrderPrice(long orderId) {
            Order relevantOrder = context.Order.FirstOrDefault(r => r.Id == orderId);
            relevantOrder.PriceOrder = 0;
            foreach (OrderPos Positions in relevantOrder.Positions) {
                relevantOrder.PriceOrder += Positions.PricePos;
                context.SaveChanges();
            }
        }
    }
}

