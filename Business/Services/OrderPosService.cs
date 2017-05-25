using Database;
using System.Linq;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using System;

namespace Business.Services
{
    public class OrderPosService
    {
        private readonly IDataService data;
        private readonly OrderService orderService;
        private readonly WaitlessContext context;

        public OrderPosService(IDataService data, OrderService orderService)
        {
            this.data = data;
            this.orderService = orderService;
            context = data.GetContext();
        }

        ~OrderPosService()
        {
            context.Dispose();
        }

        public OrderModel AddOrderPos(long orderId, long itemTypeId)
        {
            var relevantOrder = context.Order
                .Include(o => o.Positions)
                .FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return null;
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

            return orderService.GetOrder(orderId);
        }

        public OrderModel RemoveOrderPos(long orderId, long positionId)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return null;
            }

            var relevantPos = relevantOrder.Positions.FirstOrDefault(p => p.Id == positionId);
            if (relevantPos == null)
            {
                return null;
            }

            relevantOrder.Positions.Remove(relevantPos);
            context.SaveChanges();

            return orderService.GetOrder(orderId);
        }

        public OrderModel DoUpdateOrderPosRequest(long orderPosId, int amount, string comment)
        {
            var relevantOrderPos = context.OrderPos
                .Include(o => o.Itemtyp)
                .FirstOrDefault(r => r.Id == orderPosId);

            if (relevantOrderPos == null)
            {
                return null;
            }

            // Anpassung der Menge + löschen der Position falls sie 0 ist
            relevantOrderPos.Amount = amount;
            relevantOrderPos.Comment = comment;
            relevantOrderPos.PricePos = relevantOrderPos.Amount * relevantOrderPos.Itemtyp.ItemPrice;
            if (relevantOrderPos.Amount <= 0)
            {
                context.OrderPos.Remove(relevantOrderPos);
            }

            context.SaveChanges();

            return orderService.GetOrder(relevantOrderPos.OrderId);
        }

        public OrderPosModel DoChangeStatusOrderPos(long orderPosId, PosStatus status )
        {
            var relevantOrderPos = context.OrderPos
                .Include(o => o.Itemtyp)
                .FirstOrDefault(o => o.Id == orderPosId);

            relevantOrderPos.PosStatus = status;
            context.SaveChanges();

            return OrderPosModel.MapFromDatabase(relevantOrderPos);
        }
    }
}