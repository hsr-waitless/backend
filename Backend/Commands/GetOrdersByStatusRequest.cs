using Database.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetOrdersByStatusRequest
    {
        [JsonProperty("status")]
        public PosStatus Status { get; set; }
    }
}