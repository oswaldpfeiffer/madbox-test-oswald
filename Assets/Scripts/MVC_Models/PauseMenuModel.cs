
public class PauseMenuModel : IPauseMenuModel
{
    public PauseMenuModel()
    {
    }

    public bool AudioIsOn { get ; set; }
    public bool HapticIsOn { get; set; }
    public bool IsInMainMenu { get; set; }
}
