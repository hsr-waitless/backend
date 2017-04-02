using System;
using System.Collections.Generic;
using Business.Models;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace Backend.Commands
{
    public class ItemtypeResponse
    {
        [JsonProperty("items")]
        public IEnumerable<ItemTypeModel> Itemtypes { get; set; }
    }
}
