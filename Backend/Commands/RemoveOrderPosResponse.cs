using Newtonsoft.Json;
using Business.Models;
using System;

namespace Backend.Commands
{
    public class RemoveOrderPosResponse
    {
        [JsonProperty ("success")]
        public Boolean Success { get; set; }
    }
}
