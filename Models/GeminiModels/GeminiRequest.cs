using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class GeminiRequest
{
    [JsonPropertyName("systemInstruction")]
    public SystemInstruction SystemInstruction { get; set; }

    [JsonPropertyName("contents")] public List<Content> Contents { get; set; }
}