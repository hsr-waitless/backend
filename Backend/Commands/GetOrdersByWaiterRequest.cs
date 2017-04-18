using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class GetOrdersByWaiterRequest
    {
        [JsonProperty("tabletIdentifier")]
        public string TabletIdentifier { get; set; }
    }
}

