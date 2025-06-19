using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class SystemInstruction
{
    [JsonPropertyName("parts")] public List<Part> Parts { get; set; }
}