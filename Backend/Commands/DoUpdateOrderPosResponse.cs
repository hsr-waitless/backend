using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoUpdateOrderPosResponse
    {
        [JsonProperty("orderPos")]
        public OrderPos OrderPos { get; set; }
    }
}