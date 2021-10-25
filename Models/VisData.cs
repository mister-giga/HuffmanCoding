using System.Text.Json.Serialization;

namespace HuffmanCoding.Models
{
    public class VisData
    {
        [JsonPropertyName("nodes")]
        public List<VisNode> Nodes { get; } = new List<VisNode>();
        [JsonPropertyName("edges")]
        public List<VisNodeConnection> Connections { get; } = new List<VisNodeConnection>();
    }
}
