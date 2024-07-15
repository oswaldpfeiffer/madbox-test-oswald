using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinFailScreenView : MonoBehaviour, IWinFailScreenView
{
    [SerializeField] private GameObject _textWin;
    [SerializeField] private GameObject _textFail;
    [SerializeField] private Button _buttonNextLevel;
    [SerializeField] private Button _buttonMainMenu;
    [SerializeField] private Button _buttonTryAgain;

    [SerializeField] private Animator _winFailAnimator;

    public Action OnNextLevelClicked { get; set; }
    public Action OnMainMenuClicked { get; set; }
    public Action OnTryAgainClicked { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Hide()
    {
        _winFailAnimator.SetTrigger(AnimatorParameters.TRIGGER_WINFAILSCREEN_HIDE);
    }

    public void Initialize()
    {
        _buttonNextLevel.onClick.AddListener(() => OnNextLevelClicked?.Invoke());
        _buttonMainMenu.onClick.AddListener(() => OnMainMenuClicked?.Invoke());
        _buttonTryAgain.onClick.AddListener(() => OnTryAgainClicked?.Invoke());
    }

    private void OnDestroy()
    {
        _buttonNextLevel.onClick.RemoveAllListeners();
        _buttonMainMenu.onClick.RemoveAllListeners();
        _buttonTryAgain.onClick.RemoveAllListeners();
    }

    public void ShowFail()
    {
        _winFailAnimator.SetTrigger(AnimatorParameters.TRIGGER_WINFAILSCREEN_OPEN);
        _textWin.SetActive(false);
        _textFail.SetActive(true);
        _buttonNextLevel.gameObject.SetActive(false);
        _buttonMainMenu.gameObject.SetActive(true);
        _buttonTryAgain.gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        _winFailAnimator.SetTrigger(AnimatorParameters.TRIGGER_WINFAILSCREEN_OPEN);
        _textWin.SetActive(true);
        _textFail.SetActive(false);
        _buttonNextLevel.gameObject.SetActive(true);
        _buttonMainMenu.gameObject.SetActive(false);
        _buttonTryAgain.gameObject.SetActive(false);
    }

    public void UpdateView()
    {
        throw new System.NotImplementedException();
    }
}
