using System.Text.Json.Serialization;

namespace ProfiledAi.Models.GeminiModels;

public class Part
{
    [JsonPropertyName("text")] public string Text { get; set; }
}