﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ConfigurationValue
    {
        [Key]
        public long Id { get; set; }
        public String Value { get; set; }
        public Double PriceApproximation { get; set; }

        public Configuration Configuration { get; set; }
        public OrderPos OrderPos { get; set; }
    }
}
