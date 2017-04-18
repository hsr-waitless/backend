using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class TableService
    {
        private readonly WaitlessContext context;

        public TableService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<TableModel> GetAllTables()
        {
            return context.Table
            .AsEnumerable()
            .Select(m => new TableModel
                {
                    Id = m.Id,
                    Name = m.Name
                });
        }
    }
}
