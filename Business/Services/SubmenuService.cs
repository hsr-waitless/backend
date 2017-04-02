using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Bussiness.Services
{
    public class SubMenuService
    {
        private WaitlessContext context;

        public SubMenuService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<SubMenuModel> GetSubMenus(long id)
        {
            return context.Submenu
            .Where(m => m.MenuId == id)
            .ToList()
            .Select(m =>
            {
                return new SubMenuModel
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

