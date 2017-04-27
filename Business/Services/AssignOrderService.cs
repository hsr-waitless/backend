using Business.Models;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class AssignOrderService
    {
        private readonly WaitlessContext context;

        public AssignOrderService( WaitlessContext context)
        {
            this.context = context;
        }

        public bool OnOrderAssigned(string tabletIdentifier, long orderId)
        {
            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return false;
            }

            
            var tablet = context.Tablet.FirstOrDefault(t => t.Identifier == tabletIdentifier);
            if (tablet == null)
            {
                return false;
            }



            relevantOrder.Guests.Add(tablet);

            context.SaveChanges();
            
            return true;
            
        }

        public bool OnOrderUnassigned(string tabletIdentifier, long orderId) {

            var relevantOrder = context.Order.FirstOrDefault(o => o.Id == orderId);
            if (relevantOrder == null)
            {
                return false;
            }


            var tablet = context.Tablet.FirstOrDefault(t => t.Identifier == tabletIdentifier);
            if (tablet == null)
            {
                return false;
            }

            relevantOrder.Guests.Remove(tablet);

            context.SaveChanges();
            return true;
        }
    }
}