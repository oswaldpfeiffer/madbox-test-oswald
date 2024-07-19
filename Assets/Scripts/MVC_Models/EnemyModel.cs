using UnityEngine;

public class EnemyModel : IEnemyModel
{
    public float Health { get ; set; }
    public bool IsAlive { get; set; }
    public float MaxHealth { get; set; }
    public SOEnemyData EnemyData { get; set; }
    public EEnemyState EnemyState { get; set; }

    public float LastAttackTime { get; set; }
}
