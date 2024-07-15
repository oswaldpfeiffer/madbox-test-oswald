using System;

public class WinFailScreenController : IWinFailScreenController
{
    private readonly IWinFailScreenModel _model;
    private readonly IWinFailScreenView _view;

    public WinFailScreenController (IWinFailScreenModel model, IWinFailScreenView view)
    {
        _model = model;
        _view = view;

        // Subscribe to view events
        _view.OnNextLevelClicked += OnNextLevelHandler;
        _view.OnMainMenuClicked += OnMainMenuHandler;
        _view.OnTryAgainClicked += OnTryAgainHandler;
        EventBus.OnLevelWin += ShowWinScreen;
        EventBus.OnLevelFail += ShowFailScreen;
    }

    private void OnTryAgainHandler()
    {
        EventBus.TriggerTryAgainLevel();
        HideScreen();
    }

    private void OnMainMenuHandler()
    {
        EventBus.TriggerOpenMainMenu();
        HideScreen();
    }

    private void OnNextLevelHandler()
    {
        EventBus.TriggerNextLevel();
        HideScreen();
    }

    public void ShowWinScreen()
    {
        _view.ShowWin();
    }

    public void ShowFailScreen()
    {
        _view.ShowFail();
    }

    public void HideScreen()
    {
        _view.Hide();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _view.OnNextLevelClicked -= OnNextLevelHandler;
            _view.OnMainMenuClicked -= OnMainMenuHandler;
            _view.OnTryAgainClicked -= OnTryAgainHandler;
            EventBus.OnLevelWin -= ShowWinScreen;
            EventBus.OnLevelFail -= ShowFailScreen;
        }
    }
}
