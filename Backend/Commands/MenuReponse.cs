using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Commands
{
    public class MenuResponse
    {
        public IEnumerable<Menu> Menus { get; set; }
    }
}
