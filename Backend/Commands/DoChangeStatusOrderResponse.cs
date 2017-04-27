
using Business.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class DoChangeStatusOrderResponse
    {
       [JsonProperty("order")]
       public OrderModel Order { get; set; }
    }
}

