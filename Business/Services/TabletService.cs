using Business.Models;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class TabletService
    {
        private readonly IDataService data;
        private readonly WaitlessContext context;

        public TabletService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~TabletService()
        {
            context.Dispose();
        }

        public string GetTabletIdentifier(long orderPosId)
        {
            var orderPos = context.OrderPos
                .Include(o => o.Order.Waiter)
                .FirstOrDefault(o => o.Id == orderPosId);

            return orderPos.Order.Waiter.Identifier;
        }

        public IEnumerable<TabletModel> GetTablets(Mode mode)
        {
            return context.Tablet
                .Where(t => t.Mode == mode)
                .ToList()
                .Select(t => new TabletModel
                {
                    Identifier = t.Identifier,
                    Mode = t.Mode,
                    OrderId = context.Order
                        .FirstOrDefault(o => (
                                                 o.OrderStatus == OrderStatus.New
                                                 || o.OrderStatus == OrderStatus.Active)
                                             && o.Guests.Any(g => g.Id == t.Id))
                        ?.Id
                });
        }

        public bool SetMode(string tabletIdentifier, Mode tabletMode)
        {
            var tabletWasFound = false;

            //Looking for Tablet
            var searchedTablet = context.Tablet
                .FirstOrDefault(m => m.Identifier == tabletIdentifier);

            if (searchedTablet == null)
            {
                searchedTablet = new Tablet
                {
                    Identifier = tabletIdentifier,
                    Mode = tabletMode
                };

                context.Tablet.Add(searchedTablet);
            }
            else
            {
                tabletWasFound = true;
                searchedTablet.Mode = tabletMode;
            }

            context.SaveChanges();
            return tabletWasFound;
        }
    }
}