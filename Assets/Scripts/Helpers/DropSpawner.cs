using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour, IDropSpawner
{
    [SerializeField] private GameObject _weaponDropPrefab;

    private IWeaponsManager _weaponManager;

    public void Initialize(IWeaponsManager weaponManager)
    {
        _weaponManager = weaponManager;
    }

    public void DropWeapon ()
    {
        GameObject weaponDrop = Instantiate(_weaponDropPrefab);
        SOHeroWeapon weapon = _weaponManager.PickWeaponRandomly();
        weaponDrop.GetComponent<WeaponDrop>().Initialize(weapon, _weaponManager);
        weaponDrop.transform.position = transform.position;

    }
}
