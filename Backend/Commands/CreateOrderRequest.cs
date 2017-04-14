using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class CreateOrderRequest
    {

        [JsonProperty("tabletID")]
        public int TabletId { get; set; }

    }
}
