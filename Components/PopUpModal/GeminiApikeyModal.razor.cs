using Microsoft.AspNetCore.Components;
using ProfiledAi.Models;
using ProfiledAi.Models.CacheModel;
using ProfiledAi.Services;
using ProfiledAi.Utils;

namespace ProfiledAi.Components.PopUpModal;

public partial class GeminiApikeyModal : ComponentBase
{
    [Inject] public LocalStorageCaching LocalStorageCaching { get; set; } = null!;
    private readonly PopUpModel _model = Constant.GetGeminiApiKeyInputModel();
    private string _apiKey = Constant.ApiKey;
    private async Task SaveApiKey()
    {
        if (string.IsNullOrWhiteSpace(_apiKey))
        {
            return;
        }
        Constant.ApiKey = _apiKey;
        var geminiApiKeyCache = new GeminiApiKeyCacheModel
        {
            ApiKey = _apiKey,
        };
        await LocalStorageCaching.SaveItemAsync(GeminiApiKeyCacheModel.GeminiApiKeyCache, geminiApiKeyCache);
    }
}