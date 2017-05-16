using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoDeleteOrderPosRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("positionId")]
        public long PositionId { get; set; }
    }
}