using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Order
    {

        public Int32 number { get; set; }
        public Enum orderStatus { get; set; }
        public DateTime creationTime { get; set; }
        public DateTime updateTime { get; set; }
        public Double priceOrder { get; set; }

    }
}
