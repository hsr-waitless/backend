using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;


namespace Bussiness.Services
{   
    public class ItemtypService
    {
        private WaitlessContext context;

        public IEnumerable<ItemtypModel> GetMenus(SubmenuModel id)
        {
            return context.Itemtyp
            .AsEnumerable()
            //.Where<submenuId == this.id>     //sollte menuId's überprüfen
            .Select(m =>
            {
                return new ItemtypModel
                {
                    Id = m.Id,
                    Number = m.Number,
                    Title = m.Title,
                    Description = m.Description,
                    ItemPrice = m.ItemPrice,
                    Category = m.Category,
                    Image = m.Image,
                    Priority = m.Priority
                };
            });
        }


    }
}
