using System.Text.Json.Serialization;

namespace HuffmanCoding.Models
{
    public class VisNodeConnection
    {
        [JsonPropertyName("from")]
        public string? From { get; set; }
        [JsonPropertyName("to")]
        public string? To { get; set; }

    }
}
