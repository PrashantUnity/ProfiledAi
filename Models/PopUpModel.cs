namespace ProfiledAi.Models;

public class PopUpModel
{
    public string ModelId { get; set; } = "exampleModal";
    public string AriaLabelledby { get; set; } = "exampleAriaLabelledby";
    
    public string GetCallerModelId()
    {
        return $"#{ModelId}";
    }
}