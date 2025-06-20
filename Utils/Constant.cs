using ProfiledAi.Models;

namespace ProfiledAi.Utils;

public class Constant
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
}