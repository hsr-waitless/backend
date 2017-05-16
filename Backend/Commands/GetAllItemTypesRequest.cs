using Newtonsoft.Json;

namespace Backend.Commands
{
    public class GetAllItemTypesRequest
    {
        [JsonProperty("menuId")]
        public long MenuId { get; set; }
    }
}