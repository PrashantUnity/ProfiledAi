using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class CandidatesTokensDetail
{
    [JsonPropertyName("modality")] public string Modality { get; set; }

    [JsonPropertyName("tokenCount")] public int TokenCount { get; set; }
}