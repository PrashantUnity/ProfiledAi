using ProfiledAi.Models;
using ProfiledAi.Models.CacheModel;
using ProfiledAi.Services;

namespace ProfiledAi.DataBase;

public class PersonalModelDataHandler(LocalStorageCaching localStorageCaching)
{
    private List<PersonaModel> personaItems = [];

    public List<PersonaModel> GetPersonaList()
    {
        return personaItems;
    }
    public void AddPersona(PersonaModel persona)
    {
        if (!personaItems.Any(p => p.Id == persona.Id))
        {
            personaItems.Add(persona);
        }
    }
    public void RemovePersona(Guid id)
    {
        var persona = personaItems.FirstOrDefault(p => p.Id == id);
        if (persona != null)
        {
            personaItems.Remove(persona);
        }
    }
    public void UpdatePersona(PersonaModel updatedPersona)
    {
        var index = personaItems.FindIndex(p => p.Id == updatedPersona.Id);
        if (index != -1)
        {
            personaItems[index] = updatedPersona;
        }
    }
    public PersonaModel? GetPersonaById(Guid id)
    {
        return personaItems.FirstOrDefault(p => p.Id == id);
    }
    public async Task SaveToLocalStorageAsync(List<PersonaModel> personaList)
    {
        await localStorageCaching.SaveItemAsync(PersonalCacheModel.PersonaLocalCache, personaList);
    }
    public async Task SaveToLocalStorageAsync()
    {
        await localStorageCaching.SaveItemAsync(PersonalCacheModel.PersonaLocalCache, personaItems);
    }
    public async Task ClearFromLocalStorageAsync()
    {
        await localStorageCaching.ClearItemAsync(PersonalCacheModel.PersonaLocalCache);
    }
    public async Task<List<PersonaModel>> LoadFromLocalStorageAsync()
    {
        var cachedData = await localStorageCaching.GetItemListAsync<List<PersonaModel>>(PersonalCacheModel.PersonaLocalCache);
        if (cachedData != null)
        {
            personaItems = cachedData;
        }
        return personaItems;
    }
}