using ProfiledAi.Models;

namespace ProfiledAi.Utils;

public static class Constant
{
    public const string MessageSentType = "sent";
    public const string MessageReceivedType = "received";
    public const string Active = "active"; 
    public static string ApiKey = string.Empty;

    public static PopUpModel GetGeminiApiKeyInputModel()
    {
        return new PopUpModel()
        {
            HeaderTitle = "Gemini Flash 1.5",
            AriaLabelledby = "GeminiApiKeyModel",
            ModelId = "GeminiApiKeyModelId",
            PlaceHolder ="Enter Gemini Api key ..."
        };
    }
    public static string ToggleClass(string classcontent, string textToToggle)
    {
        if (classcontent.Contains(textToToggle))
        {
            return classcontent.Replace(textToToggle, string.Empty).Trim();
        }
        return $"{classcontent} {textToToggle}".Trim();
    }
}