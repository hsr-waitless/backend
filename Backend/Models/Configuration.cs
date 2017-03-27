using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Configuration
    {
        [Key]
        public long Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<ConfigurationValue> Values { get; set; }
    }
}
