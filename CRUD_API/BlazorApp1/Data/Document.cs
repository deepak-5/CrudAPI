using Nest;
using Newtonsoft.Json;

namespace BlazorApp1.Data
{
    public class Document
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Tontent")]
        public string Content { get; set; }
    }
}
