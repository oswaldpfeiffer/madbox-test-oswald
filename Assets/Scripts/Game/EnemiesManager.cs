using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemiesManager : MonoBehaviour, IEnemiesManager
{
    private ILogger _logger;

    private Dictionary<string, GameObject> _enemyPrefabs = new Dictionary<string, GameObject>();

    public void Initialize (SOLevelData levelData, Action onInitializationComplete)
    {
        _logger = ServiceLocator.Instance.GetService<ILogger>();
        /*
string key = levelData.EnemySO.PrefabAddressable;
UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<GameObject>(key).Completed += handle =>
{
    OnPrefabLoaded(handle, key);
    onInitializationComplete?.Invoke();
};
*/
        onInitializationComplete?.Invoke();
    }

    /*
    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle, string key)
    {
        if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            _enemyPrefabs.Add(key, handle.Result);
        }
        else
        {
            _logger.Log("Failed to load the enemy prefab from Addressables.", ELogLevel.Error);
        }
    }
    */


    public List<IEnemyController> SpawnEnemies(IHeroController hero, SOLevelData levelData)
    {
        List<IEnemyController> enemies = new List<IEnemyController>();
        GetRandomPositionOnMap(levelData);

        return enemies;
    }

    // Callback method when the prefab is loaded


    private Vector3 GetRandomPositionOnMap(SOLevelData levelData)
    {
        return new Vector3(0, 0, 0);
        /*
        float x = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
        float z = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
        return new Vector3(x, 0, z);
        */
    }

}
