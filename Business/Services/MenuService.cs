using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class MenuService
    {
        private WaitlessContext context;

        public MenuService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<MenuModel> GetMenus()
        {
            return context.Menu
            .AsEnumerable()
            .Select(m =>
            {
                return new MenuModel
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
