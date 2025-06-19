using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class UsageMetadata
{
    [JsonPropertyName("promptTokenCount")] public int PromptTokenCount { get; set; }

    [JsonPropertyName("candidatesTokenCount")]
    public int CandidatesTokenCount { get; set; }

    [JsonPropertyName("totalTokenCount")] public int TotalTokenCount { get; set; }

    [JsonPropertyName("promptTokensDetails")]
    public List<PromptTokensDetail> PromptTokensDetails { get; set; }

    [JsonPropertyName("candidatesTokensDetails")]
    public List<CandidatesTokensDetail> CandidatesTokensDetails { get; set; }
}