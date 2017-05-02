using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class RemoveOrderPosRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("positionId")]
        public long PositionId { get; set; }
    }
}