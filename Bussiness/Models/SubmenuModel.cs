using Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
public class SubmenuModel
{
    public SubmenuModel()
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("Menu")]
        public long Number { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }
    }
}
