using System;
using Newtonsoft.Json;

namespace Backend.Command
{
    public class GetItemTypesRequest
    {
        [JsonProperty("subMenuId")]
        public long SubMenuId { get; set; }
    }
}