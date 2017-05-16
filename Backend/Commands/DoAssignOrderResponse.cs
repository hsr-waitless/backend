using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoAssignOrderResponse
    {
        [JsonProperty("success")]
        public Boolean success { get; set; }
    }
}