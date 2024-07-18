
using System;

public class PauseMenuController : IPauseMenuController
{
    private readonly IPauseMenuModel _model;
    private readonly IPauseMenuView _view;

    private readonly ISettingsManager _settingsManager;
    private readonly ISceneManager _sceneManager;
    private readonly IAudioManager _audioManager;

    public PauseMenuController(IPauseMenuModel model, IPauseMenuView view, ISettingsManager settingsManager, ISceneManager sceneManager, IAudioManager audioManager)
    {
        _model = model;
        _view = view;
        _settingsManager = settingsManager;
        _sceneManager = sceneManager;
        _audioManager = audioManager;

        _view.OnPauseClicked += OnPauseHandler;
        _view.OnResumeClicked += OnResumeHandler;
        _view.OnAudioToggleClicked += OnAudioToggleHandler;
        _view.OnHapticToggleClicked += OnHapticToggleHandler;
        _view.OnMainMenuClicked += OnMainMenuHandler;
        UpdateModel();
        UpdateView();
    }

    private void UpdateModel ()
    {
        _model.AudioIsOn = _settingsManager.IsAudioOn();
        _model.HapticIsOn = _settingsManager.IsHapticOn();
        _model.IsInMainMenu = _sceneManager.IsInMainMenu();
    }

    private void UpdateView ()
    {
        _view.UpdateView(_model);
    }

    private void OnMainMenuHandler()
    {
        _audioManager.PlayAudioClip(EAudioClip.Click);
        TogglePauseMenu(false);
        UnityEngine.Time.timeScale = 1;
        EventBus.TriggerOpenMainMenu();
    }

    private void OnHapticToggleHandler()
    {
        _audioManager.PlayAudioClip(EAudioClip.Click);
        _settingsManager.SetHapticState(!_settingsManager.IsHapticOn());
        UpdateModel();
        UpdateView();
    }

    private void OnAudioToggleHandler()
    {
        _audioManager.PlayAudioClip(EAudioClip.Click);
        _settingsManager.SetAudioState(!_settingsManager.IsAudioOn());
        _audioManager.UpdateAudioState();
        UpdateModel();
        UpdateView();
    }

    private void OnResumeHandler()
    {
        _audioManager.PlayAudioClip(EAudioClip.Cancel);
        UnityEngine.Time.timeScale = 1;
        TogglePauseMenu(false);
    }

    private void OnPauseHandler()
    {
        _audioManager.PlayAudioClip(EAudioClip.Click);
        UnityEngine.Time.timeScale = 0;
        TogglePauseMenu(true);
    }

    public void TogglePauseMenu(bool state)
    {
        UpdateModel();
        UpdateView();
        _view.Toggle(state);
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
            _view.OnPauseClicked -= OnPauseHandler;
            _view.OnResumeClicked -= OnResumeHandler;
            _view.OnAudioToggleClicked -= OnAudioToggleHandler;
            _view.OnHapticToggleClicked -= OnHapticToggleHandler;
            _view.OnMainMenuClicked -= OnMainMenuHandler;
        }
    }
}
