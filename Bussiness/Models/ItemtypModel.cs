using Database.Models;
using Newtonsoft.Json;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ItemtypModel
{
	public ItemtypModel()
	{
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("number")]
        public Int32 Number { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("description")]
        public String Description { get; set; }

        [JsonProperty("itemPrice")]
        public double ItemPrice { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("image")]
        public String Image { get; set; }

        [JsonProperty("priority")]
        public Int32 Priority { get; set; }
    }
}
