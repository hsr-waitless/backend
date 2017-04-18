using Business.Models;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class AssignTabletService
    {
        private readonly WaitlessContext context;

        public AssignTabletService( WaitlessContext context)
        {
            this.context = context;
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