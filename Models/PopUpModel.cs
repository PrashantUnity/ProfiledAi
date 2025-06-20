namespace ProfiledAi.Models;

public class PopUpModel
{
    public string HeaderTitle { get; set; } = string.Empty;
    public string ModelId { get; set; } = "exampleModal";
    public string AriaLabelledby { get; set; } = "exampleAriaLabelledby";
    public string PlaceHolder { get; set; } = string.Empty;
    public string GetCallerModelId()
    {
        return $"#{ModelId}";
    }
}