using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class CreateOrderRequest
    {
        [JsonProperty("tabletIdentifier")]
        public string TabletIdentifier { get; set; }

        [JsonProperty("tableId")]
        public long TableId { get; set; }

    }
}
