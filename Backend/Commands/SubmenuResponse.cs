using System;
using System.Collections.Generic;
using Business.Models;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Backend.Commands
{
    public class SubmenuResponse
    {
        [JsonProperty("submenus")]
        public IEnumerable<SubMenuModel> Submenues { get; set; }
    }
}


