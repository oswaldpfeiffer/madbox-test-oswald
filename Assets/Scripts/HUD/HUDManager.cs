using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : SingletonBaseClass<HUDManager>
{
    [SerializeField] private GameObject _virtualJoystickHolder;
    IVirtualJoystick _virtualJoystick;

    [SerializeField] private GameObject _playerHealthBarHolder;
    IHealthBar _playerHealthBar;

    [SerializeField] private Image _weaponSprite;

    // Start is called before the first frame update
    void Start()
    {
        _virtualJoystick = _virtualJoystickHolder.GetComponent(typeof(IVirtualJoystick)) as IVirtualJoystick;
        ServiceLocator.Instance.GetService<IInputsManager>().SetVirtualJoystick(_virtualJoystick);

        _playerHealthBar = _playerHealthBarHolder.GetComponent(typeof(IHealthBar)) as IHealthBar;
    }

    private void OnEnable()
    {
        EventBus.OnWeaponEquipped += DisplayWeapon;
        EventBus.OnPlayerInitialized += PlayerInitialized;
    }

    private void OnDisable()
    {
        EventBus.OnWeaponEquipped -= DisplayWeapon;
        EventBus.OnPlayerInitialized -= PlayerInitialized;
    }

    private void PlayerInitialized()
    {
        EventBus.TriggerPlayerHealthBarLoaded(_playerHealthBar);
    }

    private void DisplayWeapon (SOHeroWeapon weapon)
    {
        _weaponSprite.sprite = weapon.Preview;
    }


}
