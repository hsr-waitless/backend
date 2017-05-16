using Newtonsoft.Json;
using Business.Models;
using System;

namespace Backend.Commands
{
    public class DoDeleteOrderPosResponse
    {
        [JsonProperty("order")]
        public OrderModel Order { get; set; }
    }
}