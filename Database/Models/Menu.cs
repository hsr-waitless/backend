using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Menu
    {
        [Key]
        public long Id { get; set; }
        public Int32 Number { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<Submenu> Submenus { get; set; }

    }
}
