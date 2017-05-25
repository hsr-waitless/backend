using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Database.Models;

namespace Business.Services
{
    public class TableService
    {
        private readonly IDataService data;

        public TableService(IDataService data)
        {
            this.data = data;
        }

        public IEnumerable<TableModel> GetAllTables()
        {
            using (var context = data.GetContext())
            {
                return context.Table
                    .Where(t => !t.Orders.Any(o => o.OrderStatus == OrderStatus.Active ||
                                                   o.OrderStatus == OrderStatus.New))
                    .ToList()
                    .Select(m => TableModel.MapFromDatabase(m, true))
                    .OrderBy(o => o.Name)
                    .Union(context.Table
                        .Where(t => t.Orders.Any(o => o.OrderStatus == OrderStatus.Active ||
                                                      o.OrderStatus == OrderStatus.New))
                        .ToList()
                        .Select(m => TableModel.MapFromDatabase(m, false))
                        .OrderBy(o => o.Name));
            }
        }
    }
}