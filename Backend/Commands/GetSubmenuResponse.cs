using Newtonsoft.Json;
using Business.Models;
using System.Collections.Generic;

namespace Backend.Commands
{
    public class GetSubMenuResponse
    {
        [JsonProperty("subMenus")]
        public IEnumerable<SubmenuModel> SubMenus { get; set; }
    }
}