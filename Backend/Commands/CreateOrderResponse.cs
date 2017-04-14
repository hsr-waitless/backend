using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class CreateOrderResponse
    {
        [JsonProperty ("order")]
        public Order Order { get; set; }
    }
}
