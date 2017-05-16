using System.Collections.Generic;
using Business.Models;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetAllItemTypesResponse
    {
        [JsonProperty("items")]
        public IEnumerable<ItemTypeModel> ItemTypes { get; set; }
    }
}