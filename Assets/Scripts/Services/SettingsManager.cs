using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : BaseService<ISettingsManager>, ISettingsManager
{
    [SerializeField] private SOGameSettings SettingsSO;

    private IPersistentDataManager _persistentDataManager;

    void Start ()
    {
        _persistentDataManager = ServiceLocator.Instance.GetService<IPersistentDataManager>();
    }

    public bool IsAudioOn()
    {
        return _persistentDataManager.GetInt(PlayerPrefKeys.KEY_AUDIO, 1) == 1;
    }

    public bool IsHapticOn()
    {
        return _persistentDataManager.GetInt(PlayerPrefKeys.KEY_HAPTICS, 1) == 1;
    }

    public void SetAudioState(bool on)
    {
        _persistentDataManager.SaveInt(PlayerPrefKeys.KEY_AUDIO, on ? 1 : 0);
    }

    public void SetHapticState(bool on)
    {
        _persistentDataManager.SaveInt(PlayerPrefKeys.KEY_HAPTICS, on ? 1 : 0);
    }
}
