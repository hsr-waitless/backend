using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class DoChangeStatusOrderPosResponse
    {
        [JsonProperty("orderPos")]
        public OrderPosModel OrderPos { get; set; }
    }
}

