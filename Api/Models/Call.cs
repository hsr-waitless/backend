using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Call
    {
        public DateTime creationTime { get; set; }
        public DateTime updateTime { get; set; }
        public Enum callStatus { get; set; }
        public Enum type { get; set; }
    }
}
