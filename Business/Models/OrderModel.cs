using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class OrderModel
    {
        [JsonProperty ("number")]
        public long Number { get; set; }
        
        [JsonProperty ("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonProperty ("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty ("priceOrder")]
        public double PriceOrder { get; set; }

        [JsonProperty ("positions")]
        public List<OrderPos> Positions { get; set; }

        [JsonProperty ("guests")]
        public List<Tablet> Guests { get; set; }
    }
}

