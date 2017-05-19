using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class CreateOrderPosRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("itemTypeId")]
        public long ItemTypeId { get; set; }
    }
}