using Newtonsoft.Json;

namespace Backend.Commands
{
    public class AllItemTypesRequest
    {
        [JsonProperty ("menuId")]
        public long MenuId { get; set; }
    }
}