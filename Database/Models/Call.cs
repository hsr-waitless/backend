using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Call
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public CallStatus CallStatus { get; set; }
        public Type Type { get; set; }

        public Order Order { get; set; }
        public Tablet Tablet { get; set; }
    }
}
