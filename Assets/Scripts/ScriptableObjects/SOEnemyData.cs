using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEnemyData", menuName = "ScriptableObjects/SOEnemyData", order = 7)]
public class SOEnemyData : ScriptableObject
{
    public string PrefabAddressable;
    public SOHealth HealthSO;
    public int Damages;
    public float AttackCooldown;
    public float MoveSpeed;
    public float AttackRange;
    public float MinDistanceToPlayer;
    public int ScorePerKill;
}
