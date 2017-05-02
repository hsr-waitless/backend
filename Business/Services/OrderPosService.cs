using Database;
using System.Linq;
using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class OrderPosService
    {
        private readonly WaitlessContext context;

        public OrderPosService(WaitlessContext context)
        {
            this.context = context;
        }

        public OrderPosModel DoUpdateOrderPosRequest(long orderPosId, int amount,
            double pricePaidByCustomer, string comment)
        {
            var relevantOrderPos = context.OrderPos
                .Include(o => o.Itemtyp)
                .FirstOrDefault(r => r.Id == orderPosId);

            // Anpassung der Menge + löschen der Position falls sie 0 ist
            relevantOrderPos.Amount += amount;
            if (relevantOrderPos.Amount <= 0)
            {
                relevantOrderPos.Order.Positions.Remove(relevantOrderPos);
            }
            relevantOrderPos.PricePos = relevantOrderPos.Amount * pricePaidByCustomer;

            // TODO es fehlen weitere Update- Möglichkeiten für comment

            context.SaveChanges();

            return OrderPosModel.MapFromDatabase(relevantOrderPos);
        }
    }
}