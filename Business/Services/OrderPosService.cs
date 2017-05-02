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

            // Anpassung der Menge + löschen der Position falls sie 0 ist
            relevantOrderPos.Amount = amount;
            relevantOrderPos.Comment = comment;
            if (relevantOrderPos.Amount <= 0)
            {
                relevantOrderPos.Order.Positions.Remove(relevantOrderPos);
            }
            relevantOrderPos.PricePos = relevantOrderPos.Amount * relevantOrderPos.Itemtyp.ItemPrice;

            // TODO es fehlen weitere Update- Möglichkeiten für comment

            context.SaveChanges();

            return orderService.GetOrder(relevantOrderPos.OrderId);
        }
    }
}