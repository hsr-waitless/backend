﻿using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;


namespace Bussiness.Services
{   
    public class ItemTypeService
    {
        private WaitlessContext context;

        public ItemTypeService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<ItemTypeModel> GetItemTypes(long id)
        {
            return context.Itemtyp
            .Where(i => i.SubmenuId == id)
            .ToList()
            .Select(m =>
            {
                return new ItemTypeModel
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