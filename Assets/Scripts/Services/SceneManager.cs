using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : BaseService<ISceneManager>, ISceneManager
{
    void Start()
    {
        EventBus.OnOpenMainMenu += LoadMenuScene;
        EventBus.OnTryAgainLevel += ReloadCurrentScene;
    }

    private void LoadMenuScene ()
    {
        LoadScene(ScenesIndexing.SCENE_MENU);
    }

    private void ReloadCurrentScene ()
    {
        LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int sceneIndex, Action onComplete = null)
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex, onComplete));
    }

    public void LoadSceneAdditive(int sceneIndex, Action onComplete = null)
    {
        StartCoroutine(LoadSceneAdditiveCoroutine(sceneIndex, onComplete));
    }

    public void UnloadScene(int sceneIndex, Action onComplete = null)
    {
        StartCoroutine(UnloadSceneCoroutine(sceneIndex, onComplete));
    }

    private IEnumerator LoadSceneCoroutine(int sceneIndex, Action onComplete)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        onComplete?.Invoke();
    }

    private IEnumerator LoadSceneAdditiveCoroutine(int sceneIndex, Action onComplete)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        onComplete?.Invoke();
    }

    private IEnumerator UnloadSceneCoroutine(int sceneIndex, Action onComplete)
    {
        AsyncOperation asyncUnload = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        onComplete?.Invoke();
    }

    public bool IsInMainMenu()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == ScenesIndexing.SCENE_MENU;
    }
}
