using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class GetTabletsByModeRequest
    {
        [JsonProperty("mode")]
        public Mode Mode { get; set; }
    }
}

