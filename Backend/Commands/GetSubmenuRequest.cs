using System;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetSubMenuRequest
    {
        [JsonProperty("menuId")]
        public long MenuId { get; set; }
    }
}