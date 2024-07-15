using System;

public interface IPauseMenuView : IView
{
    Action OnPauseClicked { get; set; }
    Action OnResumeClicked { get; set; }
    Action OnAudioToggleClicked { get; set; }
    Action OnHapticToggleClicked { get; set; }
    Action OnMainMenuClicked { get; set; }
    void Toggle(bool state);
    void UpdateView(IPauseMenuModel model);
}
