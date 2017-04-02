using Newtonsoft.Json;
using Business.Models;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Backend.Commands
{
    public class SubmenuResponse
    {
        [JsonProperty ("Submenus")]
        public IEnumerable<SubmenuModel> Submenues { get; set; }
    }
}


