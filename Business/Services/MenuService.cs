using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Business.Services
{
    public class MenuService
    {
        private readonly IDataService data;

        public MenuService(IDataService data)
        {
            this.data = data;
        }

        public IEnumerable<MenuModel> GetMenus()
        {
            using (var context = data.GetContext())
            {
                return context.Menu
                    .ToList()
                    .Select(m => MenuModel.MapFromDatabse(m));
            }
        }
    }
}