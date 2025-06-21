using Microsoft.AspNetCore.Components;
using ProfiledAi.Models.CacheModel;
using ProfiledAi.Services;
using ProfiledAi.Utils;

namespace ProfiledAi.Layout;

public partial class CahcheModelComponents : ComponentBase
{
    [Inject] public LocalStorageCaching LocalStorageCaching { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    { 
        await GetGeminiApiKey();
    }
    private async Task GetGeminiApiKey()
    {
        var apiKeyCacheModel = await LocalStorageCaching.GetItemAsync<GeminiApiKeyCacheModel>(GeminiApiKeyCacheModel.GeminiApiKeyCache);
        Constant.ApiKey = apiKeyCacheModel?.ApiKey??string.Empty;
    }
}