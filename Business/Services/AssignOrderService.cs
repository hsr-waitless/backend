using Business.Models;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AssignOrderService
    {
        private readonly IDataService data;
        private readonly WaitlessContext context;

        public AssignOrderService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~AssignOrderService()
        {
            context.Dispose();
        }

        public bool OnOrderAssigned(string tabletIdentifier, long orderId)
        {
            var relevantOrder = context.Order
                .Include(o => o.Guests)
                .FirstOrDefault(o => o.Id == orderId);

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

        public bool OnOrderUnassigned(string tabletIdentifier, long orderId)
        {
            var relevantOrder = context.Order
                .Include(o => o.Guests)
                .FirstOrDefault(o => o.Id == orderId);

            if (relevantOrder == null)
            {
                return false;
            }


            var tablet = relevantOrder.Guests.FirstOrDefault(t => t.Identifier == tabletIdentifier);
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