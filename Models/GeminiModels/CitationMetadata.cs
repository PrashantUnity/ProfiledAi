using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class CitationMetadata
{
    [JsonPropertyName("citationSources")] public List<CitationSource> CitationSources { get; set; }
}