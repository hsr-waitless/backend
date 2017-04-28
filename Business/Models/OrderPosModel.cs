using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class OrderPosModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty ("number")]
        public long Number { get; set; }

        [JsonProperty("pricePaidByCustomer")]
        public double PricePaidByCustomer { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("pricePos")]
        public double PricePos { get; set; }
                
        [JsonProperty ("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("updateTime")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("posStatus")]
        public PosStatus PosStatus { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("itemType")]
        public long Itemtype { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }
        
    }
}

