using System;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class SubMenuRequest
    {
        [JsonProperty("menuId")]
        public long MenuId { get; set; }
    }
}