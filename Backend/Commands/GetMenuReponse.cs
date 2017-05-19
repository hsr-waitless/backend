using System.Collections.Generic;
using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class GetMenuResponse
    {
        [JsonProperty("menus")]
        public IEnumerable<MenuModel> Menus { get; set; }
    }
}