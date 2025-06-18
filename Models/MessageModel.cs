namespace ProfiledAi.Models;

public class MessageModel
{
    public string MessageText { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    
    public string MessageType { get; set; } = "sent";
}