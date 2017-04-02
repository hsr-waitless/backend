using System;
using Newtonsoft.Json;

namespace Backend.Command
{
    public class ItemTypeRequest
    {
        [JsonProperty ("subMenuId")]
        public long SubMenuId { get; set; }
    }
}
