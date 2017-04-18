using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Database.Models;

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
                .Where(t => !t.Orders.Any(o => o.OrderStatus == OrderStatus.Active || o.OrderStatus == OrderStatus.New))
                .Select(m => new TableModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Available = true
                    })
                .OrderBy(o => o.Name)
                .Union(context.Table
                .Where(t => t.Orders.Any(o => o.OrderStatus == OrderStatus.Active || o.OrderStatus == OrderStatus.New))
                .Select(m => new TableModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Available = false
                })
                .OrderBy(o => o.Name));
        }
    }
}
