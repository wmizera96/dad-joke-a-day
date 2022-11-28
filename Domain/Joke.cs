using Newtonsoft.Json;

namespace Domain
{
    public record Joke
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }

        public string Type { get; set; }

        public int Date { get; set; }

        [JsonProperty("NSFW")]
        public bool Nsfw { get; set; }

        public string ShareableLink { get; set; }
    }
}
