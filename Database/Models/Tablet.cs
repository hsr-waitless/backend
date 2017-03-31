﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Tablet
    {
        [Key]
        public long Id { get; set; }
        public Int32 Number { get; set; }
        public Mode Mode { get; set; }

        public List<Call> Calls { get; set; }

    }
}