namespace ProfiledAi.Utils;

public class ModelUri
{
    public static string GetGeminiPath(string apiKey)
    {
        return $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";
    }
}