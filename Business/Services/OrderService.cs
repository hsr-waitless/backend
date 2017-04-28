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
                    Positions = m.Positions
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
                    Positions = m.Positions,
                    Guests = m.Guests
                })
                .FirstOrDefault();
        }

        public OrderPos CreateOrderPos(long orderId) {
            return new OrderPos()
            {

                
                Number = context.Order.FirstOrDefault(o => o.Id == orderId).Positions.Count() + 1,
                CreationDate = DateTime.Now,
                PosStatus = PosStatus.New,
                OrderId = orderId
             };
            
        }

        public bool AddOrderPos(long orderId, OrderPos position) {
            if (orderId == null || position.Id == null)
            {
                return false;
            }

            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            relevantOrder.Positions.Add(position);
            context.SaveChanges();
            return true;
        }

        public bool RemoveOrderPos(long orderId, long positionId)
        {
            if (orderId == null || positionId == null)
            {
                return false;
            }
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            relevantOrder.Positions.Remove(relevantOrder.Positions.FirstOrDefault(p => p.Id == positionId));
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
    }
}

