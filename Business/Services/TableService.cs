using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Bussiness.Services
{
    public class TableService
    {
        private WaitlessContext context;

        public TableService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<TableModel> GetTables()
        {
            return context.Table
            .AsEnumerable()
            .Select(m =>
            {
                return new TableModel
                {
                    Id = m.Id,
                    Name = m.Name
                };
            });
        }
    }
}
