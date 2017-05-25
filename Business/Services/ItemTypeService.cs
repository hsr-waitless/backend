using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Business.Services
{
    public class ItemTypeService
    {
        private readonly IDataService data;

        public ItemTypeService(IDataService data)
        {
            this.data = data;
        }

        public IEnumerable<ItemTypeModel> GetItemTypes(long subMenuId)
        {
            using (var context = data.GetContext())
            {
                return context.Itemtyp
                    .Where(i => i.SubmenuId == subMenuId)
                    .ToList()
                    .Select(m => ItemTypeModel.MapFromDatabase(m));
            }
        }


        public IEnumerable<ItemTypeModel> GetAllItemTypes(long menuId)
        {
            using (var context = data.GetContext())
            {
                return context.Itemtyp
                    .Include(i => i.Submenu)
                    .Where(i => i.Submenu.MenuId == menuId)
                    .ToList()
                    .Select(m => ItemTypeModel.MapFromDatabase(m));
            }
        }
    }
}