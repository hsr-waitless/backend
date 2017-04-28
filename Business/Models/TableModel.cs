using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class TableModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        public static TableModel MapFromDatabase(Table table, Boolean available) {
            return new TableModel {
                Id = table.Id,
                Name = table.Name,
                Available = available
        };
        }
        
    }
}