using System;

public interface ISceneManager : IService
{
    void LoadScene(int sceneIndex, System.Action onComplete = null);
    void LoadSceneAdditive(int sceneIndex, System.Action onComplete = null);
    void UnloadScene(int sceneIndex, System.Action onComplete = null);
    bool IsInMainMenu();
}
