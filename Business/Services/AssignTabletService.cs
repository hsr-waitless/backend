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
        private WaitlessContext context;
        public AssignTabletService( WaitlessContext context)
        {
            this.context = context;
        }

        public Boolean AssignTablet( String tabletIdentifier, Mode tabletMode)
        {
            Boolean tabletWasFound = false;

            //Looking for Tablet
            var searchedTablet = context.Tablet
            .FirstOrDefault(m => m.Identifier == tabletIdentifier);

            if( searchedTablet == null)
            {
                searchedTablet = new Tablet();
                searchedTablet.Identifier = tabletIdentifier;

                searchedTablet.Mode = tabletMode;
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