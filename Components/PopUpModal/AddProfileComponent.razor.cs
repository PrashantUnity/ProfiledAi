using Microsoft.AspNetCore.Components;
using ProfiledAi.DataBase;
using ProfiledAi.Models;
using ProfiledAi.Utils;
namespace ProfiledAi.Components.PopUpModal;
public partial class AddProfileComponent : ComponentBase
{
    [Inject] public PersonalModelDataHandler LocalStorageCaching { get; set; } = null!;
    private readonly PopUpModel _model = Constant.GetProfileInputModel();
    private PersonaModel _persona = new();
    private bool _isSavingToDatabase = false;
    private async Task Save()
    { 
        if (string.IsNullOrWhiteSpace(_persona.Name))
        {
            return;
        }

        _isSavingToDatabase = true;
        StateHasChanged();
        var models = LocalStorageCaching.GetPersonaList();
        _persona.Id = Guid.NewGuid();
        models.Add(_persona);
        await LocalStorageCaching.ClearFromLocalStorageAsync();
        await LocalStorageCaching.SaveToLocalStorageAsync(models);
        _isSavingToDatabase = false;
        StateHasChanged();
    }
}