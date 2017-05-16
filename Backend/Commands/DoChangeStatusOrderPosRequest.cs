using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoChangeStatusOrderPosRequest
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("status")]
        public PosStatus Status { get; set; }
    }
}

