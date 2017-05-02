using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class SubmenuModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        public static SubmenuModel MapFromDatabase(Submenu m)
        {
            return new SubmenuModel
            {
                Id = m.Id,
                Number = m.Number,
                Name = m.Name,
                Description = m.Description
            };
        }
    }
}