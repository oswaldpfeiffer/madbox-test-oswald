using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour, IEnemiesManager
{
    public List<IEnemyController> SpawnEnemies()
    {
        List<IEnemyController> enemies = new List<IEnemyController>();


        return enemies;
    }


    private Vector3 GetRandomPositionOnMap()
    {
        return new Vector3(0, 0, 0);
        /*
        float x = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
        float z = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
        return new Vector3(x, 0, z);
        */
    }

}
