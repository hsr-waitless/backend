using Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Commands
{
    public class GetTabletsByModeResponse
    {
        [JsonProperty("tablets")]
        public IEnumerable<TabletModel> Tablets { get; set; }
    }
}