using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class SubmenuService
    {
        private WaitlessContext context;

        public SubmenuService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<SubmenuModel> GetSubmenus(long id)
        {
            return context.Submenu
            .Where(m => m.MenuId == id)
            .ToList()
            .Select(m =>
            {
                return new SubmenuModel
                {
                    Id = m.Id,
                    Number = m.Number,
                    Name = m.Name,
                    Description = m.Description
                };
            });
        }
    }
}

