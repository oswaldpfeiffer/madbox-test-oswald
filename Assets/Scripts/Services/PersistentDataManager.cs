using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : BaseService<IPersistentDataManager>, IPersistentDataManager
{
    public void SaveInt (string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveString (string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public int GetInt (string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public string GetString(string key, string defaultValue)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public float GetFloat(string key, float defaultValue)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public int GetCurrentLevel()
    {
        return GetInt(PlayerPrefKeys.KEY_LEVEL, 0);
    }

    public void SetCurrentLevel(int level)
    {
        SaveInt(PlayerPrefKeys.KEY_LEVEL, level);
    }
}
