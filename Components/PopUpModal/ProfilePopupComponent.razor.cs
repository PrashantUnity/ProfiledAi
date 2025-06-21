using Microsoft.AspNetCore.Components;
using ProfiledAi.DataBase;
using ProfiledAi.Models;
using ProfiledAi.Models.CacheModel;
using ProfiledAi.Services;
using ProfiledAi.Utils;

namespace ProfiledAi.Components.PopUpModal;

public partial class ProfilePopupComponent : ComponentBase
{
    [Inject] public PersonalModelDataHandler LocalStorageCaching { get; set; } = null!;
    [Parameter,EditorRequired] public PersonaModel Persona { get; set; } = null!;
    private readonly PopUpModel _model = Constant.GetProfiledAiSettingsInputModel();
    private async Task SaveProfile()
    {
        var models = LocalStorageCaching.GetPersonaList();
        foreach (var model in models)
        {
            if (model.Id == Persona.Id)
            {
                model.Name = Persona.Name;
                model.Avatar = Persona.Avatar;
                model.IsActive = Persona.IsActive;
            }
        }
        await LocalStorageCaching.ClearFromLocalStorageAsync();
        await LocalStorageCaching.SaveToLocalStorageAsync(models);
        StateHasChanged();
    }
}