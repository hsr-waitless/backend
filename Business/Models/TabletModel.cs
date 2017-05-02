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

        [JsonProperty("orderId")]
        public long? OrderId { get; set; }

        public static TabletModel MapFromDatabase(Tablet tablet)
        {
            return new TabletModel()
            {
                Identifier = tablet.Identifier,
                Mode = tablet.Mode
            };
        }
    }
}