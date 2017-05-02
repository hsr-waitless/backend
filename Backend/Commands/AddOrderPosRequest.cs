using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class AddOrderPosRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("itemTypeId")]
        public long ItemTypeId { get; set; }
    }
}