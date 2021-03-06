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
        private readonly IDataService data;
        private readonly WaitlessContext context;

        public ItemTypeService(IDataService data)
        {
            this.data = data;
            context = data.GetContext();
        }

        ~ItemTypeService()
        {
            context.Dispose();
        }

        public IEnumerable<ItemTypeModel> GetItemTypes(long subMenuId)
        {
            return context.Itemtyp
                .Where(i => i.SubmenuId == subMenuId)
                .ToList()
                .Select(m => ItemTypeModel.MapFromDatabase(m));
        }


        public IEnumerable<ItemTypeModel> GetAllItemTypes(long menuId)
        {
            return context.Itemtyp
                .Include(i => i.Submenu)
                .Where(i => i.Submenu.MenuId == menuId)
                .ToList()
                .Select(m => ItemTypeModel.MapFromDatabase(m));
        }
    }
}