using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class AddOrderPosResponse
    {
        [JsonProperty("order")]
        public OrderModel Order { get; set; }
    }
}