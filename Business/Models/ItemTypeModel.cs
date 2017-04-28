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

        [JsonProperty("image")]
        public String Image { get; set; }

        [JsonProperty("priority")]
        public Int32 Priority { get; set; }

        public static ItemTypeModel MapFromDatabase(Itemtyp m) {
            return new ItemTypeModel
            {
                Id = m.Id,
                Number = m.Number,
                Title = m.Title,
                Description = m.Description,
                ItemPrice = m.ItemPrice,
                Category = m.Category,
                Image = m.Image,
                Priority = m.Priority
            };
        }
    }
}
