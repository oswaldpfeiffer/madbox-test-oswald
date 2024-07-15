using System;

public interface IWinFailScreenView : IView
{
    Action OnNextLevelClicked { get; set; }
    Action OnMainMenuClicked { get; set; }
    Action OnTryAgainClicked { get; set; }

    void ShowWin();
    void ShowFail();
    void Hide();
}
