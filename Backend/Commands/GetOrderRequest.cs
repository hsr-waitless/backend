using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetOrderRequest
    {
        [JsonProperty("number")]
        public long Number { get; set; }
    }
}