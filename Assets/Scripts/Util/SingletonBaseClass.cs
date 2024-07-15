using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBaseClass<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            OnSingletonInitialized();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnSingletonInitialized()
    {
        // Custom initialization logic
    }
}
