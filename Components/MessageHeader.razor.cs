using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProfiledAi.Models;
using ProfiledAi.Utils;

namespace ProfiledAi.Components;

public partial class MessageHeader : ComponentBase
{
    [Parameter, EditorRequired] public PersonaModel Model { get; set; }
    [Inject] private IJSRuntime  JsRuntime { get; set; } = null!;
    [Parameter] public EventCallback<string> ToggleClass { get; set; }

    private async Task HideSidebar()
    {
        var size = await JsRuntime.InvokeAsync<WindowSize>("getWindowSize");
        Console.WriteLine($"Width: {size.Width}, Height: {size.Height}");
        if (size.Width < 768)
        {
            await ToggleClass.InvokeAsync($"active");
        }
    }
}