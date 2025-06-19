using Microsoft.AspNetCore.Components;
using ProfiledAi.Models;

namespace ProfiledAi.Pages;

public partial class Home : ComponentBase
{
    private readonly List<PersonaModel> _personaModels =
    [
        new PersonaModel()
        {
            UnreadCount = 0,
            Name = "John Doe",
            LastMessage = "Hi there! How are you doing?",
            Time = DateTime.Now,
            Avatar = "J",
        },
        new PersonaModel()
        {
            UnreadCount = 2,
            Name = "Jane Smith",
            LastMessage = "Let's catch up later.",
            Time = DateTime.Now.AddMinutes(-10),
            Avatar = "JS",
        },
    ];

    private readonly List<MessageModel> _messageModels =
    [
        new MessageModel()
        {
            MessageType = "sent",
            MessageText = "Hello! How can I assist you today?",
            SentAt = DateTime.Now.AddMinutes(-5),
        },
        new MessageModel()
        {
            MessageType = "received",
            MessageText = "I'm looking for some information on Blazor components.",
            SentAt = DateTime.Now.AddMinutes(-3),
        },
    ];

    private PersonaModel _selectedPersona = new PersonaModel()
    {
        Name = "John Doe",
        SystemPrompt = "You are a helpful assistant.",
        Avatar = "JD"
    };

    protected override Task OnInitializedAsync()
    {
        _selectedPersona.MessageList = _messageModels;
        return base.OnInitializedAsync();
    }
}