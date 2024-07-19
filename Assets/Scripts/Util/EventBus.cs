using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    public static event Action<EGameState> OnGameStateChanged;
    public static event Action OnOpenMainMenu;
    public static event Action OnTryAgainLevel;
    public static event Action OnNextLevel;
    public static event Action OnLevelWin;
    public static event Action OnLevelFail;
    public static event Action OnPlayerInitialized;
    public static event Action<IHealthBar> OnPlayerHealthBarLoaded;
    public static event Action<SOHeroWeapon> OnWeaponEquipped;
    public static event Action<int> OnEnemyKilled;

    public static void TriggerGameStateChanged(EGameState state)
    {
        OnGameStateChanged?.Invoke(state);
    }
    public static void TriggerOpenMainMenu()
    {
        OnOpenMainMenu?.Invoke();
    }
    public static void TriggerTryAgainLevel()
    {
        OnTryAgainLevel?.Invoke();
    }
    public static void TriggerNextLevel()
    {
        OnNextLevel?.Invoke();
    }
    public static void TriggerLevelWin()
    {
        OnLevelWin?.Invoke();
    }
    public static void TriggerLevelFail()
    {
        OnLevelFail?.Invoke();
    }
    public static void TriggerPlayerHealthBarLoaded(IHealthBar healthbar)
    {
        OnPlayerHealthBarLoaded?.Invoke(healthbar);
    }
    public static void TriggerOnWeaponEquipped(SOHeroWeapon weapon)
    {
        OnWeaponEquipped?.Invoke(weapon);
    }
    public static void TriggerOnPlayerInitialized()
    {
        OnPlayerInitialized?.Invoke();
    }

    public static void TriggerOnEnemyKilled(int score)
    {
        OnEnemyKilled?.Invoke(score);
    }
    /*
    // Generic events alternative, more practical but less explicit...

    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public static void Subscribe(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void Unsubscribe(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
    */
}