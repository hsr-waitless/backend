using Database.Models;
using Newtonsoft.Json;

namespace Business.Models
{
    public class TabletModel
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

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

