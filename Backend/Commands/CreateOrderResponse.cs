using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class CreateOrderResponse
    {
        [JsonProperty ("order")]
        public OrderModel Order { get; set; }
    }
}
