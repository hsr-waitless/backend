using Database;
using System.Linq;
using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class OrderPosService
    {
        private readonly WaitlessContext context;
        private readonly OrderService orderService;

        public OrderPosService(WaitlessContext context, OrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
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
    }
}