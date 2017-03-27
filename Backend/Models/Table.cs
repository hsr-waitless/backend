using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Table
    {
        [Key]
        public long Id { get; set; }
        public String Name { get; set; }

    }
}
