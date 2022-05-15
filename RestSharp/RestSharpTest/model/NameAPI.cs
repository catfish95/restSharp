using Newtonsoft.Json;

namespace RestSharpTest.model
{
    public class NameAPI
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}
