using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.ViewModels;
using Newtonsoft.Json;

namespace Backend.Commands
{
    public class MenuResponse
    {
        [JsonProperty("menus")]
        public IEnumerable<MenuViewModel> Menus { get; set; }
    }
}
