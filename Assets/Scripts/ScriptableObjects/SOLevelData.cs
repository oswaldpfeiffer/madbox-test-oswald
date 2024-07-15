using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOLevelData", menuName = "ScriptableObjects/SOLevelData", order = 7)]
public class SOLevelData : ScriptableObject
{
    public SOEnemyData EnemySO;
    public int EnemiesAmount;
    public float MinXSpawn;
    public float MaxXSpawn;
    public float MinYSpawn;
    public float MaxYSpawn;
}
