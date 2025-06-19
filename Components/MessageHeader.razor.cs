using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProfiledAi.Utils;

namespace ProfiledAi.Components;

public partial class MessageHeader : ComponentBase
{
    [Inject] private IJSRuntime  JsRuntime { get; set; } = null!;

    private async Task HideSidebar()
    {
        await JsRuntime.InvokeVoidAsync("hideSidebar");
    }
}