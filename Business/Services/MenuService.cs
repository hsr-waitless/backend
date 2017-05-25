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
        private readonly WaitlessContext context;

        public MenuService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~MenuService()
        {
            context.Dispose();
        }

        public IEnumerable<MenuModel> GetMenus()
        {
            return context.Menu
                .ToList()
                .Select(m => MenuModel.MapFromDatabse(m));
        }
    }
}