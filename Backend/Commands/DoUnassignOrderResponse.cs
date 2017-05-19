using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoUnassignOrderResponse
    {
        [JsonProperty("success")]
        public Boolean success { get; set; }
    }
}