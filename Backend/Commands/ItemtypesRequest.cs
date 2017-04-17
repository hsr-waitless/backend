using System;
using Newtonsoft.Json;

namespace Backend.Command
{
    public class ItemTypesRequest
    {
        [JsonProperty ("subMenuId")]
        public long SubMenuId { get; set; }
    }
}
