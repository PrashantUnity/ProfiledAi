using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class Candidate
{
    [JsonPropertyName("content")] public Content Content { get; set; }

    [JsonPropertyName("finishReason")] public string FinishReason { get; set; }

    [JsonPropertyName("citationMetadata")] public CitationMetadata CitationMetadata { get; set; }

    [JsonPropertyName("avgLogprobs")] public double AvgLogprobs { get; set; }
}