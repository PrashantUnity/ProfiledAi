namespace ProfiledAi.Models;

public class PersonaModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsLoading { get; set; } = false;
    public string IsActive { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime Time { get; set; }
    public string LastMessage { get; set; } = string.Empty;
    public int UnreadCount { get; set; }
    
    public string SystemPrompt { get; set; } = string.Empty;

    public List<MessageModel> MessageList = new();
}