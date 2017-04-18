using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetOrdersByWaiterRequest
    {
        [JsonProperty("tabletIdentifier")]
        public string TabletIdentifier { get; set; }
    }
}

