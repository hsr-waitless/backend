using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class CreateOrderPosResponse
    {
        [JsonProperty("order")]
        public OrderModel Order { get; set; }
    }
}