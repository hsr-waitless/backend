using System;
using Database;
using System.Collections.Generic;
using Business.Models;
using System.Linq;

namespace Bussiness.Services
{
    public class SubmenuService
    {
        private WaitlessContext context;
        public SubmenuService(WaitlessContext context)
        {
            this.context = context;
        }

        public IEnumerable<SubmenuModel> GetSubmenus( MenuModel menuId)
        {
            return context.Submenu
            .AsEnumerable()
            //.Where<menuId == this.id>     //sollte menuId's überprüfen
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

