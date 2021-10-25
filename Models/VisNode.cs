using System.Text.Json.Serialization;

namespace HuffmanCoding.Models
{
    public class VisNode
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("label")]
        public string? Label { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }

    }
}
