using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class GeminiResponse
{
    [JsonPropertyName("candidates")] public List<Candidate> Candidates { get; set; }

    [JsonPropertyName("usageMetadata")] public UsageMetadata UsageMetadata { get; set; }

    [JsonPropertyName("modelVersion")] public string ModelVersion { get; set; }

    [JsonPropertyName("responseId")] public string ResponseId { get; set; }
}