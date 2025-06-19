using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class Content
{
    [JsonPropertyName("parts")] public List<Part> Parts { get; set; }

    [JsonPropertyName("role")] public string Role { get; set; }
}