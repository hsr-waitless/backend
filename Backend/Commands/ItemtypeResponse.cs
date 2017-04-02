using System;
using System.Collections.Generic;
using Business.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class ItemTypeResponse
    {
        [JsonProperty("items")]
        public IEnumerable<ItemTypeModel> ItemTypes { get; set; }
    }
}
