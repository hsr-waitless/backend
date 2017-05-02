using Newtonsoft.Json;

namespace Backend.Commands
{
    public class DoUpdateOrderPosRequest
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("orderPosId")]
        public long OrderPosId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}