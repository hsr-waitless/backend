using System;
using Newtonsoft.Json;

namespace Business.Models
{
    public class MenuModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public Int32 Number { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }
    }
}
