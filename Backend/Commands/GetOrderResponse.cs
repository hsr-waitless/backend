using Business.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetOrderResponse
    {
        [JsonProperty("order")]
        public OrderModel Order { get; set; }
    }
}