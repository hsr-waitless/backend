using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class SubmenuService
    {
        private readonly IDataService data;

        public SubmenuService(IDataService data)
        {
            this.data = data;
        }

        public IEnumerable<SubmenuModel> GetSubmenus(long id)
        {
            using (var context = data.GetContext())
            {
                return context.Submenu
                    .Where(m => m.MenuId == id)
                    .ToList()
                    .Select(m => SubmenuModel.MapFromDatabase(m));
            }
        }
    }
}