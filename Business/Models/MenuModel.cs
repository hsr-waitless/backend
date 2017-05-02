using System;
using Newtonsoft.Json;
using Database.Models;

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

        public static MenuModel MapFromDatabse(Menu m) {
            if (m == null)
            {
                return null;
            }

            return new MenuModel
            {
                Id = m.Id,
                Number = m.Number,
                Name = m.Name,
                Description = m.Description
            };
        }
    }
}
