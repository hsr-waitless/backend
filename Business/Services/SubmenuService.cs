using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class SubmenuService
    {
        private readonly IDataService data;
        private readonly WaitlessContext context;

        public SubmenuService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~SubmenuService()
        {
            context.Dispose();
        }

        public IEnumerable<SubmenuModel> GetSubmenus(long id)
        {
            return context.Submenu
                .Where(m => m.MenuId == id)
                .ToList()
                .Select(m => SubmenuModel.MapFromDatabase(m));
        }
    }
}