using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Itemtyp
    {

        public Int32 number { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public Double itemPrice { get; set; }
        public Enum categorie { get; set; }
        public String image { get; set; }
        public Int32 priority { get; set; }
    }
}
