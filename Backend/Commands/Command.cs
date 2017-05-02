using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class Command<TArgument>
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("arguments")]
        public TArgument Arguments { get; set; }
    }
}