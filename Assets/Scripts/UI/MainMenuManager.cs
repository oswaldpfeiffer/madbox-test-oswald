using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour, IMainMenuManager
{
    [SerializeField] Button PlayButton;

    private ISceneManager _sceneManager;
    private IAudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _sceneManager = ServiceLocator.Instance.GetService<ISceneManager>();
        _audioManager = ServiceLocator.Instance.GetService<IAudioManager>();
        PlayButton.onClick.AddListener(() => StartGame());
    }

    void OnDisable ()
    {
        PlayButton.onClick.RemoveAllListeners();
    }

    private void StartGame ()
    {
        _audioManager.PlayAudioClip(EAudioClip.Click);
        _sceneManager.LoadScene(ScenesIndexing.SCENE_GAME);
    }
}
