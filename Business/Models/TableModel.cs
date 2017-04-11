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
        public String Name { get; set; }
        
    }
}