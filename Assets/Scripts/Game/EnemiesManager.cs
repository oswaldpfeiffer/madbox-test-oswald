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

        string key = levelData.EnemySO.PrefabAddressable;
        Addressables.LoadAssetAsync<GameObject>(key).Completed += handle =>
        {
            OnPrefabLoaded(handle, key);
            onInitializationComplete?.Invoke();
        };
    }

    private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle, string key)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _enemyPrefabs.Add(key, handle.Result);
        }
        else
        {
            _logger.Log("Failed to load the enemy prefab from Addressables.", ELogLevel.Error);
        }
    }

    public List<IEnemyController> SpawnEnemies(IHeroController hero, SOLevelData levelData)
    {
        List<IEnemyController> enemies = new List<IEnemyController>();
        GameObject enemy = _enemyPrefabs[levelData.EnemySO.PrefabAddressable];
        if (enemy != null)
        {
            for(int i = 0; i < levelData.EnemiesAmount; i++)
            {
                Vector3 pos = GetRandomPositionOnMap(levelData);
                GameObject go = Instantiate(enemy, pos, Quaternion.identity, null);
                IEnemyController controller = go.GetComponent(typeof(IEnemyController)) as IEnemyController;
                IEnemyModel model = new EnemyModel();
                controller.Initialize(hero, model, levelData.EnemySO.HealthSO);
                enemies.Add(controller);
            }
        }
        return enemies;
    }

    private Vector3 GetRandomPositionOnMap(SOLevelData levelData)
    {
        int xSign = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        int ySign = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float x = xSign * UnityEngine.Random.Range(levelData.MinXSpawn, levelData.MaxXSpawn);
        float y = ySign * UnityEngine.Random.Range(levelData.MinYSpawn, levelData.MaxYSpawn);
        return new Vector3(x, 0, y);
    }

}
