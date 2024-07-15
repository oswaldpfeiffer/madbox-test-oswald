using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WeaponsManager : MonoBehaviour, IWeaponsManager
{
    private ILogger _logger;
    [SerializeField] List<SOHeroWeapon> _weapons;
    private Dictionary<SOHeroWeapon, GameObject> _weaponPrefabs = new Dictionary<SOHeroWeapon, GameObject>();
    private int _assetsToLoad;
    private int _assetsLoaded;
    public void Initialize(Action onInitializationComplete)
    {
        _logger = ServiceLocator.Instance.GetService<ILogger>();
        _assetsToLoad = _weapons.Count;
        _assetsLoaded = 0;

        foreach (SOHeroWeapon weaponSO in _weapons)
        {
            string prefabAddressable = weaponSO.PrefabAddressable;
            Addressables.LoadAssetAsync<GameObject>(prefabAddressable).Completed += handle =>
            {
                OnPrefabLoaded(handle, weaponSO, onInitializationComplete);
            };
        }
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle, SOHeroWeapon weaponSO, Action onInitializationComplete)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _weaponPrefabs[weaponSO] = handle.Result;
        }
        else
        {
            _logger.Log($"Failed to load the enemy prefab from Addressables: {weaponSO.PrefabAddressable}", ELogLevel.Error);
        }

        _assetsLoaded++;
        if (_assetsLoaded >= _assetsToLoad)
        {
            onInitializationComplete?.Invoke();
        }
    }

    public SOHeroWeapon PickWeaponRandomly()
    {
        return _weapons[UnityEngine.Random.Range(0, _weapons.Count)];
    }

    public GameObject GetModelForWeaponSO(SOHeroWeapon weaponSO)
    {
        return _weaponPrefabs[weaponSO];
    }
}
