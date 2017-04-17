using System;
using System.Collections.Generic;
using Business.Models;
using Database.Models;
using Database;
using System.Linq;

namespace Business.Services
{
    public class GetTabletsByModeService
    {
        private WaitlessContext context;

        public GetTabletsByModeService( WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<TabletModel> GetTablets(Mode mode)
        {
            return context.Tablet
            .Where(t => t.Mode == mode)
            .ToList()
            .Select(t =>
            {
                return new TabletModel
                {
                    Id = t.Id,
                    Mode = t.Mode
                };
            });
        }
    }
}