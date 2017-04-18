using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public double PriceOrder { get; set; }

        public long TableId { get; set; }
        public Table Table { get; set; }
        public Tablet Waiter { get; set; }
        
        public List<OrderPos> Positions { get; set; }
        public List<Tablet> Guests { get; set; }
        public List<Call> Calls { get; set; }
    }
}
