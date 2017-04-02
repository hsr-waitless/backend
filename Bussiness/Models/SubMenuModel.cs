using System;
using Newtonsoft.Json;

namespace Business.Models
{
    public class SubMenuModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public Int32 Number { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
