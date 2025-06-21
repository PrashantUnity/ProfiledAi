using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components;
using ProfiledAi.Models;
using ProfiledAi.Services;
using Constant = ProfiledAi.Utils.Constant;

namespace ProfiledAi.Components;

public partial class MessageInput(Gemini gemini) : ComponentBase
{
    [Parameter, EditorRequired] public PersonaModel Model { get; set; } = null!;
    [Parameter] public EventCallback<PersonaModel> OnChange { get; set; }
    private readonly MessageModel _messageModel = new();
    private bool IsLoading { get; set; } = false;

    private async Task Send()
    {
        var message = _messageModel.MessageText;
        Model.IsLoading = true;
        IsLoading = true;
        await OnChange.InvokeAsync(Model);
        
        if (string.IsNullOrWhiteSpace(_messageModel.MessageText))
        {
            return;
        }
        _messageModel.MessageText = string.Empty;
        var response = await gemini.GenerateResponseAsync(
            apiKey:Constant.ApiKey,
            systemPrompt:Model.SystemPrompt,
            userPrompt:message);
        if (response == null)
        {
            _messageModel.MessageText = message;
            return;
        }
        Model.MessageList.Add(new MessageModel()
        {
            MessageText = message,
            MessageType = Constant.MessageSentType,
            SentAt = DateTime.Now,
        });
        try
        {
            Model.MessageList.Add( new MessageModel()
            {
                MessageText = string.Join("\n",response.Candidates.SelectMany(x=>x.Content.Parts.Select(y=>y.Text))),
                MessageType = Constant.MessageReceivedType,
                SentAt = DateTime.Now,
            });
        }
        catch (Exception e)
        {
            _messageModel.MessageText = message;
            Console.WriteLine(e.Message);
        }
        IsLoading = false;
        Model.IsLoading = false;
        await OnChange.InvokeAsync(Model);
        StateHasChanged();
    }
}