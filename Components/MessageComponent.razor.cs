using Microsoft.AspNetCore.Components;
using ProfiledAi.Models;

namespace ProfiledAi.Components;

public partial class MessageComponent : ComponentBase
{
    [Parameter, EditorRequired] public PersonaModel Model { get; set; } = null!;
    [Parameter] public EventCallback<string> ToggleSideBarClass { get; set; }

    public void UpdateModel(PersonaModel model)
    {
        Model = model;
        StateHasChanged();
    }
    public async Task SidebarVisible(string active)
    { 
        await ToggleSideBarClass.InvokeAsync(active);
    }
}