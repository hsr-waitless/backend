using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class GetOrdersByWaiterRequest
    {
        [JsonProperty("waiterId")]
        public int WaiterId { get; set; }
    }
}

