using Blazored.LocalStorage;

namespace ProfiledAi.Services;

public class LocalStorageCaching(ILocalStorageService localStorage)
{
    public async Task<TU?> GetItemAsync<TU>(string key) where TU : class
    {
        return await localStorage.GetItemAsync<TU>(key);
    }
    public async Task SetApiKeyAsync<T>(string key, T value)
    {
        await localStorage.SetItemAsync(key, value);
    }

    public async Task ClearApiKeyAsync(string key)
    {
        await localStorage.RemoveItemAsync(key);
    }
}