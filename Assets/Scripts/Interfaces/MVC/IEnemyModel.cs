using UnityEngine;

public interface IEnemyModel : IModel, IDamageableModel
{
    float LastAttackTime { get; set; }
    SOEnemyData EnemyData { get; set; }
    EEnemyState EnemyState { get; set; }
}
