using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class UnassignOrderResponse
    {
        [JsonProperty("success")]
        public Boolean success { get; set; }

    }
}

