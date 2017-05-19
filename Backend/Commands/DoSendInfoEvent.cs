using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoSendInfoEvent
    {
        [JsonProperty("info")]
        public String Info { get; set; }

        
    }
}