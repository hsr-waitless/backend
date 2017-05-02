using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<OrderPosModel> Positions { get; set; }

        [JsonProperty ("guests")]
        public IEnumerable<TabletModel> Guests { get; set; }

        public static OrderModel MapFromDatabase(Order order)
        {
            return new OrderModel()
            {
                Number = order.Id,
                Table = order.Table.Name,
                OrderStatus = order.OrderStatus,
                CreationTime = order.CreationTime,
                UpdateTime = order.UpdateTime,
                PriceOrder = order.PriceOrder,
                Positions = order.Positions?.Select(p => OrderPosModel.MapFromDatabase(p)),
                Guests = order.Guests?.Select(p => TabletModel.MapFromDatabase(p))
            };
        }
    }
}

