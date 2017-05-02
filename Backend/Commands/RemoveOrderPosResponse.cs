using Newtonsoft.Json;
using Business.Models;
using System;

namespace Backend.Commands
{
    public class RemoveOrderPosResponse
    {
        [JsonProperty("order")]
        public OrderModel Order { get; set; }
    }
}