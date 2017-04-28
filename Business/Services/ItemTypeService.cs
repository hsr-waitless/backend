﻿using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Business.Services
{   
    public class ItemTypeService
    {
        private readonly WaitlessContext context;

        public ItemTypeService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<ItemTypeModel> GetItemTypes(long subMenuId)
        {
            return context.Itemtyp
            .Where(i => i.SubmenuId == subMenuId)
            .ToList()
            .Select(m => new ItemTypeModel
                {
                    Id = m.Id,
                    Number = m.Number,
                    Title = m.Title,
                    Description = m.Description,
                    ItemPrice = m.ItemPrice,
                    Category = m.Category,
                    Image = m.Image,
                    Priority = m.Priority
                });
        }


        public IEnumerable<ItemTypeModel> GetAllItemTypes(long menuId)
        {
            return context.Itemtyp
                .Include(i => i.Submenu)
                .Where(i => i.Submenu.MenuId == menuId)
                .ToList()
                .Select(m => new ItemTypeModel
                {
                    Id = m.Id,
                    Number = m.Number,
                    Title = m.Title,
                    Description = m.Description,
                    ItemPrice = m.ItemPrice,
                    Category = m.Category,
                    Image = m.Image,
                    Priority = m.Priority
                });
        }
    }
}
