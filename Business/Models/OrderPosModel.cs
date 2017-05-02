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

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("pricePaidByCustomer")]
        public double PricePaidByCustomer { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("pricePos")]
        public double PricePos { get; set; }

        [JsonProperty("posStatus")]
        public PosStatus PosStatus { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("itemTypeId")]
        public long ItemtypeId { get; set; }

        public static OrderPosModel MapFromDatabase(OrderPos orderPos)
        {
            return new OrderPosModel()
            {
                Id = orderPos.Id,
                Number = orderPos.Number,
                PricePaidByCustomer = orderPos.PricePaidByCustomer,
                Amount = orderPos.Amount,
                PricePos = orderPos.PricePos,
                PosStatus = orderPos.PosStatus,
                Comment = orderPos.Comment,
                ItemtypeId = orderPos.ItemtypId
            };
        }
    }
}