using Database.Models;
using Newtonsoft.Json;
using System;
using Business.Models;

namespace Backend.Commands
{
    public class DoUpdateOrderPosResponse
    {
        [JsonProperty("orderPos")]
        public OrderPosModel OrderPos { get; set; }
    }
}