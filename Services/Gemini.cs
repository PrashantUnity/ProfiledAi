using System.Text;
using System.Text.Json;
using ProfiledAi.Models.GeminiModels;
using ProfiledAi.Utils;
namespace ProfiledAi.Services;
public class Gemini(HttpClient httpClient)
{
    public async Task<GeminiResponse?> GenerateResponseAsync(string apiKey, string systemPrompt, string userPrompt)
    {
        if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(systemPrompt) ||
            string.IsNullOrWhiteSpace(userPrompt))
        {
            return null;
        }
        
        var requestBody = new GeminiRequest()
        {
            SystemInstruction = new SystemInstruction
            {
                Parts =
                [
                    new Part { Text = systemPrompt }
                ]
            },
            Contents =
            [
                new Content
                {
                    Parts =
                    [
                        new Part { Text = userPrompt }
                    ]
                }
            ]
        };
        using var client = new HttpClient();
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var json = JsonSerializer.Serialize(requestBody, options);
        using var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(ModelUri.GetGeminiPath(Constant.ApiKey), httpContent);
        response.EnsureSuccessStatusCode();

        if (!response.IsSuccessStatusCode) return null;
        var responseJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GeminiResponse>(responseJson);
    }
}