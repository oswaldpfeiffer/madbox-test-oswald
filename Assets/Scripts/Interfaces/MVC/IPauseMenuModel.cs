public interface IPauseMenuModel : IModel
{
    bool AudioIsOn {get; set; }
    bool HapticIsOn { get; set; }
    bool IsInMainMenu { get; set; }
}
