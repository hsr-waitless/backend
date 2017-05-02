using Database.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class DoChangeStatusOrderRequest
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }
    }
}