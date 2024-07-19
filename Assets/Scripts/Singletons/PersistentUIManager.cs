using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersistentUIManager : SingletonBaseClass<PersistentUIManager>
{
    [SerializeField] private GameObject _winFailScreenViewHolder;
    [SerializeField] private GameObject _pauseMenuViewHolder;

    private IWinFailScreenView _winFailScreenView;
    private IPauseMenuView _pauseMenuView;
    private IWinFailScreenController winFailScreenController;
    private IPauseMenuController pauseMenuController;

    private ILogger _logger;
    private ISettingsManager _settings;
    private ISceneManager _sceneManager;
    private IAudioManager _audioManager;

    protected override void OnSingletonInitialized()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _logger = ServiceLocator.Instance.GetService<ILogger>();
        _settings = ServiceLocator.Instance.GetService<ISettingsManager>();
        _sceneManager = ServiceLocator.Instance.GetService<ISceneManager>();
        _audioManager = ServiceLocator.Instance.GetService<IAudioManager>();
        InitializeControllers();
    }

    private void InitializeControllers()
    {
        _winFailScreenView = _winFailScreenViewHolder.GetComponent(typeof(IWinFailScreenView)) as IWinFailScreenView;
        if (_winFailScreenView == null)
        {
            _logger.Log(_winFailScreenView.GetType() + " not found !", ELogLevel.Error);
            return;
        }
        WinFailScreenModel winFailScreenModel = new WinFailScreenModel();
        winFailScreenController = new WinFailScreenController(winFailScreenModel, _winFailScreenView);

        _pauseMenuView = _pauseMenuViewHolder.GetComponent(typeof(IPauseMenuView)) as IPauseMenuView;
        if (_pauseMenuView == null)
        {
            _logger.Log(_pauseMenuView.GetType() + " not found !", ELogLevel.Error);
            return;
        }
        IPauseMenuModel pauseMenuModel = new PauseMenuModel();
        pauseMenuController = new PauseMenuController(pauseMenuModel, _pauseMenuView, _settings, _sceneManager, _audioManager);
    }

    private void OnApplicationQuit()
    {
        DisposeControllers();
    }

    // Dispose all controllers and clear resources
    private void DisposeControllers()
    {
        winFailScreenController?.Dispose();
        pauseMenuController?.Dispose();
    }
}
