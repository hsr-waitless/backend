using Database;
using Database.Models;
using System;
using System.Linq;

namespace Business.Services
{
    public class CreateOrderService
    {
        private WaitlessContext context;

        public CreateOrderService(WaitlessContext context)
        {
            this.context = context;
        }

        public Order CreateOrder(int tabletId)
        {
            Order newOrder = new Order();

            // Bekannte Daten zuordnen
            newOrder.Table = context.Table
            .FirstOrDefault(m => m.Id == tabletId);
            newOrder.OrderStatus = OrderStatus.New;
            newOrder.CreationTime = DateTime.Now;
            newOrder.UpdateTime = newOrder.CreationTime;
            newOrder.PriceOrder = 0;

            // Folgendes fehlt:
            // Id muss festgelegt werden
            // Number muss festgelegt werden
            // evtl. Positions, Guests und Calls festlegen

            return newOrder;
        }



    }
}

