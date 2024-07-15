using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour, IPauseMenuView
{
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonMainMenu;
    [SerializeField] private Button _buttonResume;
    [SerializeField] private Button _buttonBackground;
    [SerializeField] private UIToggle _toggleAudio;
    [SerializeField] private UIToggle _toggleHaptics;

    [SerializeField] private Animator _pauseMenuAnimator;

    public Action OnPauseClicked { get ; set ; }
    public Action OnResumeClicked { get ; set ; }
    public Action OnAudioToggleClicked { get ; set ; }
    public Action OnHapticToggleClicked { get; set; }
    public Action OnMainMenuClicked { get; set; }

    void Start ()
    {
        Initialize();
    }

    public void Initialize()
    {
        _buttonMainMenu.onClick.AddListener(() => OnMainMenuClicked?.Invoke());
        _buttonResume.onClick.AddListener(() => OnResumeClicked?.Invoke());
        _buttonPause.onClick.AddListener(() => OnPauseClicked?.Invoke());
        _buttonBackground.onClick.AddListener(() => OnResumeClicked?.Invoke());
        _toggleAudio.GetToggleButton().onClick.AddListener(() => OnAudioToggleClicked?.Invoke());
        _toggleHaptics.GetToggleButton().onClick.AddListener(() => OnHapticToggleClicked?.Invoke());
    }

    private void OnDestroy()
    {
        _buttonMainMenu.onClick.RemoveAllListeners();
        _buttonResume.onClick.RemoveAllListeners();
        _buttonPause.onClick.RemoveAllListeners();
        _buttonBackground.onClick.RemoveAllListeners();
        _toggleAudio.GetToggleButton().onClick.RemoveAllListeners();
        _toggleHaptics.GetToggleButton().onClick.RemoveAllListeners();
    }

    private void SetContext(bool isInMainMenu)
    {
        _buttonMainMenu.gameObject.SetActive(!isInMainMenu);
    }

    private void SetAudioToggle (bool on)
    {
        _toggleAudio.SetActiveState(on);
    }

    private void SetHapticToggle(bool on)
    {
        _toggleHaptics.SetActiveState(on);
    }

    public void Toggle(bool state)
    {
        _pauseMenuAnimator.SetTrigger(state ? AnimatorParameters.TRIGGER_PAUSEMENU_OPEN : AnimatorParameters.TRIGGER_PAUSEMENU_CLOSE);
    }

    public void UpdateView(IPauseMenuModel model)
    {
        SetContext(model.IsInMainMenu);
        SetAudioToggle(model.AudioIsOn);
        SetHapticToggle(model.HapticIsOn);
    }
}
