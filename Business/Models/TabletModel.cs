using Database.Models;
using Newtonsoft.Json;
using System;

namespace Business.Models
{
    public class TabletModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mode")]
        public Mode Mode { get; set; }
        

        // Tablet wird einer Order zugewiesen für die Menüauswahl
        // benötigt OrderKlasse bevor implementiert wird
        // evtl. muss dies auch in dem Order erstellt werden

        /*[JsonProperty("order")]
        public Order Order { get; set; }
        */
        
    }
}

