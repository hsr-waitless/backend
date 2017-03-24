using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class OrderPos
    {

        public Int32 number { get; set; }
        public Double pricePaidByCustomer { get; set; }
        public Int32 amount { get; set; }
        public Double pricePos { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public Enum posStatus { get; set; }
        public String comment { get; set; }

    }
}
