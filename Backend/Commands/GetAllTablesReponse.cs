using System.Collections.Generic;
using Newtonsoft.Json;
using Business.Models;

namespace Backend.Commands
{
    public class GetAllTablesResponse
    {
        [JsonProperty("tables")]
        public IEnumerable<TableModel> Tables { get; set; }
    }
}