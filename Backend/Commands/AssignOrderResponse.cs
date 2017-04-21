using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class AssignOrderResponse
    {
        [JsonProperty("success")]
        public Boolean success { get; set; }

    }
}

