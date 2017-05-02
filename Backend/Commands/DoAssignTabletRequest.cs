using Database.Models;
using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoAssignTabletRequest
    {
        [JsonProperty("mode")]
        public Mode Mode { get; set; }

        [JsonProperty("tabletIdentifier")]
        public String TabletIdentifier { get; set; }
    }
}