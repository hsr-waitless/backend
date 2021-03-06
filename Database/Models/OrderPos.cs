﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class OrderPos
    {
        [Key]
        public long Id { get; set; }
        public Int32 Number { get; set; }
        public Double PricePaidByCustomer { get; set; }
        public Int32 Amount { get; set; }
        public Double PricePos { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public PosStatus PosStatus { get; set; }
        public String Comment { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ItemtypId { get; set; }
        public Itemtyp Itemtyp { get; set; }

        public List<ConfigurationValue> ConfigurationValues { get; set; }
    }
}
