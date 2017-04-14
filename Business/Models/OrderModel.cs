using Database.Models;
using Newtonsoft.Json;
using System;

namespace Business.Models
{
    public class OrderModel
    {
        [JsonProperty ("number")]
        public int Number { get; set; }   
        
        [JsonProperty ("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonProperty ("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty ("priceOrder")]
        public double PriceOrder { get; set; }
    }
}

