using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class UnassignOrderRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("tabletIdentifier")]
        public String TabletIdentifier { get; set; }
    }
}