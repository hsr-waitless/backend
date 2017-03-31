using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Commands
{
    public class Command<TArgument>
    {
        public string RequestId { get; set; }
        public TArgument Arguments { get; set; }
    }
}
