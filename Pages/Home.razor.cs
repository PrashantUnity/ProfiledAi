using Microsoft.AspNetCore.Components;
using ProfiledAi.DataBase;
using ProfiledAi.Models;
using ProfiledAi.Utils;

namespace ProfiledAi.Pages;

public partial class Home : ComponentBase
{
    private string _siderBarClass = $"col-md-4 col-lg-3 p-0 sidebar {Constant.Active}";
    [Inject] public PersonalModelDataHandler PersonalModelDataHandler { get; set; } = null!;
    private List<PersonaModel> _personaModels =[];
    private PersonaModel _selectedPersona = new()
    {
        Name = "John Doe",
        SystemPrompt = "You are a helpful assistant.",
        Avatar = "JD"
    };

    protected override async Task OnInitializedAsync()
    { 
        _personaModels= await PersonalModelDataHandler.LoadFromLocalStorageAsync();
        if (_personaModels.Count > 0)
        {
            _selectedPersona = _personaModels.First();
        }
        else
        {
            _personaModels.Add(_selectedPersona);
        }
    }
    private void PersonalModelSelectionChanged(PersonaModel selectedPersona)
    {
        _selectedPersona = selectedPersona;
        StateHasChanged();
    }
    private void SideBarVisible(string active)
    {
        _siderBarClass = $"col-md-4 col-lg-3 p-0 sidebar {active}";
    }

    private void ToggleSideBar(string active)
    {
        _siderBarClass = Constant.ToggleClass(_siderBarClass, active);
        StateHasChanged();
    }
}