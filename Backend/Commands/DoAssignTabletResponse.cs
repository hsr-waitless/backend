using Newtonsoft.Json;
using System;

namespace Backend.Commands
{
    public class DoAssignTabletResponse
    {
        [JsonProperty("isTabletNew")]
        public Boolean IsTabletNew { get; set; }

    }
}

