using Database.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetOrdersByStatusRequest
    {
        [JsonProperty("status")]
        public OrderStatus Status { get; set; }
    }
}