using System;
using Newtonsoft.Json;
using Database.Models;

namespace Business.Models
{
    public class ItemTypeModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public Int32 Number { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("price")]
        public Double ItemPrice { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }
    }
}
