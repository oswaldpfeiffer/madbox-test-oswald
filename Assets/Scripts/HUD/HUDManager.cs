using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : SingletonBaseClass<HUDManager>
{
    [SerializeField] private GameObject _virtualJoystickHolder;
    IVirtualJoystick _virtualJoystick;

    // Start is called before the first frame update
    void Start()
    {
        _virtualJoystick = _virtualJoystickHolder.GetComponent(typeof(IVirtualJoystick)) as IVirtualJoystick;
        ServiceLocator.Instance.GetService<IInputsManager>().SetVirtualJoystick(_virtualJoystick);
    }
}
