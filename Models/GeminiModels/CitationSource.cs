using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class CitationSource
{
    [JsonPropertyName("startIndex")] public int StartIndex { get; set; }

    [JsonPropertyName("endIndex")] public int EndIndex { get; set; }

    [JsonPropertyName("uri")] public string Uri { get; set; }
}