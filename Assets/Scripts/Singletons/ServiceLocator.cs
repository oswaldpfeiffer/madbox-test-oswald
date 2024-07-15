using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : SingletonBaseClass<ServiceLocator>
{
    private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    protected override void OnSingletonInitialized()
    {
        DontDestroyOnLoad(this);
    }

    public void RegisterService<T>(T service) where T : class, IService
    {
        Type interfaceType = typeof(T);
        if (!_services.ContainsKey(interfaceType))
        {
            _services[interfaceType] = service;
        }
        else
        {
            Debug.LogWarning($"Service of type {interfaceType} is already registered.");
        }
    }

    public T GetService<T>() where T : class, IService
    {
        var interfaceType = typeof(T);
        if (_services.TryGetValue(interfaceType, out var service))
        {
            return service as T;
        }

        Debug.LogError($"Service of type {interfaceType} is not registered.");
        return null;
    }

    public void ClearServices()
    {
        _services.Clear();
    }
}
