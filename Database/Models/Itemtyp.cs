﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Itemtyp
    {
        [Key]
        public long Id { get; set; }
        public Int32 Number { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Double ItemPrice { get; set; }
        public Category Category { get; set; }
        public String Image { get; set; }
        public Int32 Priority { get; set; }

        public long SubmenuId { get; set; }
        public Submenu Submenu { get; set; }

        public List<Configuration> Configurations { get; set; }
    }
}
