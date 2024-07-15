using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseService<TInterface> : MonoBehaviour where TInterface : class, IService
{
    protected virtual void Awake()
    {
        ServiceLocator.Instance.RegisterService(this as TInterface);
    }
}
