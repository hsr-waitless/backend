using Business.Models;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class TabletService
    {
        private readonly WaitlessContext context;

        public TabletService( WaitlessContext context)
        {
            this.context = context;
        }
        public IEnumerable<TabletModel> GetTablets(Mode mode)
        {
            return context.Tablet
            .Where(t => t.Mode == mode)
            .ToList()
            .Select(t => new TabletModel
            {
                Identifier = t.Identifier,
                Mode = t.Mode
            });
        }
        public bool SetMode( string tabletIdentifier, Mode tabletMode)
        {
            var tabletWasFound = false;

            //Looking for Tablet
            var searchedTablet = context.Tablet
            .FirstOrDefault(m => m.Identifier == tabletIdentifier);

            if( searchedTablet == null)
            {
                searchedTablet = new Tablet
                {
                    Identifier = tabletIdentifier,
                    Mode = tabletMode
                };

                context.Tablet.Add(searchedTablet);

            } else
            { 
                tabletWasFound = true;
                searchedTablet.Mode = tabletMode;
            }

            context.SaveChanges();
            return tabletWasFound;
        }
    }
}