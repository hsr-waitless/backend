using Database;
using Database.Models;
using System;
using System.Linq;

namespace Business.Services
{
    public class OrderPosService
    {
        private readonly WaitlessContext context;

        public OrderPosService(WaitlessContext context)
        {
            this.context = context;
        }

        public OrderPos DoUpdateOrderPosRequest(long orderPosId, int amount, 
            double pricePaidByCustomer, string comment)
        {
            OrderPos relevantOrderPos = context.OrderPos.
                FirstOrDefault(r => r.Id == orderPosId);

            // Anpassung der Menge + löschen der Position falls sie 0 ist
            relevantOrderPos.Amount += amount;
            if(relevantOrderPos.Amount <= 0)
            {
                relevantOrderPos.Order.Positions.Remove(relevantOrderPos);
            }

            // TODO es fehlen weitere Update- Möglichkeiten für comment

            context.SaveChanges();
            return relevantOrderPos;
        }
    }
}

