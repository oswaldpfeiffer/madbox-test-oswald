using System;
using UnityEngine;

public interface IWeaponsManager
{
    void Initialize(Action onInitializationComplete);
    SOHeroWeapon PickWeaponRandomly();
    GameObject GetModelForWeaponSO(SOHeroWeapon weaponSO);
}
