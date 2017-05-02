using Newtonsoft.Json;

namespace Backend.Commands
{
    public class DoUpdateOrderPosRequest
    {
       
        [JsonProperty("orderPosId")]
        public long OrderPosId { get; set; }

        [JsonProperty("pricePaidByCustomer")]
        public double PricePaidByCustomer { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }
    }
}