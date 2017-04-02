using Newtonsoft.Json;
using Business.Models;
using System.Collections.Generic;

namespace Backend.Commands
{
    public class SubMenuResponse
    {
        [JsonProperty ("subMenus")]
        public IEnumerable<SubMenuModel> SubMenus { get; set; }
    }
}


